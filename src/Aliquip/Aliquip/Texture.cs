﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Diagnostics;
using Silk.NET.Vulkan;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Buffer = Silk.NET.Vulkan.Buffer;
using Image = Silk.NET.Vulkan.Image;

namespace Aliquip
{
    public sealed class Texture : IDisposable
    {
        private readonly Vk _vk;
        private readonly ICommandBufferFactory _commandBufferFactory;
        private readonly ITransferQueueProvider _transferQueueProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly IGraphicsQueueProvider _graphicsQueueProvider;
        private readonly IBufferFactory _bufferFactory;
        private readonly uint _width;
        private readonly uint _height;
        private readonly ImageAspectFlags _aspectFlags;
        public Image Image { get; }
        public DeviceMemory Memory { get; }
        private ImageLayout _layout = ImageLayout.Undefined;
        public Format Format { get; }
        public ImageView ImageView { get; }
        public Sampler Sampler { get; }

        public unsafe Texture(uint width, uint height,
            Format format,
            Vk vk,
            ICommandBufferFactory commandBufferFactory,
            ITransferQueueProvider transferQueueProvider,
            ILogicalDeviceProvider logicalDeviceProvider,
            IPhysicalDeviceProvider physicalDeviceProvider,
            IGraphicsQueueProvider graphicsQueueProvider,
            IBufferFactory bufferFactory,
            bool createSampler,
            ImageAspectFlags aspectFlags,
            ImageUsageFlags imageUsageFlags)
        {
            _vk = vk;
            _commandBufferFactory = commandBufferFactory;
            _transferQueueProvider = transferQueueProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
            _physicalDeviceProvider = physicalDeviceProvider;
            _graphicsQueueProvider = graphicsQueueProvider;
            _bufferFactory = bufferFactory;
            _aspectFlags = aspectFlags;
            Format = format;

            var imageInfo = new ImageCreateInfo
            (
                imageType: ImageType.ImageType2D,
                extent: new Extent3D(width: width, height: height, depth: 1), mipLevels: 1,
                arrayLayers: 1,
                format: Format,
                tiling: ImageTiling.Optimal,
                initialLayout: ImageLayout.Undefined,
                sharingMode: SharingMode.Exclusive,
                usage: imageUsageFlags,
                samples: SampleCountFlags.SampleCount1Bit
            );

            _vk.CreateImage(_logicalDeviceProvider.LogicalDevice, imageInfo, null, out var image).ThrowCode();
            _vk.GetImageMemoryRequirements(_logicalDeviceProvider.LogicalDevice, image, out var memoryRequirements);
            
            uint FindMemoryType(uint typeFilter, MemoryPropertyFlags properties)
            {
                _vk.GetPhysicalDeviceMemoryProperties(_physicalDeviceProvider.Device, out var memoryProperties);

                for (int i = 0; i < memoryProperties.MemoryTypeCount; i++)
                {
                    if ((typeFilter & (1 << i)) != 0 && ((memoryProperties.MemoryTypes[i].PropertyFlags & properties) == properties))
                        return (uint)i;
                }

                throw new Exception("Cannot find suitable Memory Type");
            }

            var allocInfo = new MemoryAllocateInfo
            (
                allocationSize: memoryRequirements.Size,
                memoryTypeIndex: FindMemoryType
                    (memoryRequirements.MemoryTypeBits, MemoryPropertyFlags.MemoryPropertyDeviceLocalBit)
            );

            _vk.AllocateMemory(_logicalDeviceProvider.LogicalDevice, allocInfo, null, out var imageMemory).ThrowCode();

            _vk.BindImageMemory(_logicalDeviceProvider.LogicalDevice, image, imageMemory, 0);

            _width = width;
            _height = height;
            Image = image;
            Memory = imageMemory;

            ImageViewCreateInfo viewInfo = new ImageViewCreateInfo
            (
                image: Image, viewType: ImageViewType.ImageViewType2D, format: Format,
                subresourceRange: new ImageSubresourceRange
                (
                    aspectMask: _aspectFlags, baseMipLevel: 0, levelCount: 1, baseArrayLayer: 0,
                    layerCount: 1
                )
            );

            _vk.CreateImageView(_logicalDeviceProvider.LogicalDevice, viewInfo, null, out var imageView).ThrowCode();
            ImageView = imageView;

            if (createSampler)
            {
                _vk.GetPhysicalDeviceProperties(_physicalDeviceProvider.Device, out var properties);

                var samplerInfo = new SamplerCreateInfo
                (
                    magFilter: Filter.Linear, minFilter: Filter.Linear, addressModeU: SamplerAddressMode.Repeat,
                    addressModeV: SamplerAddressMode.Repeat, addressModeW: SamplerAddressMode.Repeat,
                    anisotropyEnable: true, maxAnisotropy: properties.Limits.MaxSamplerAnisotropy,
                    borderColor: BorderColor.FloatOpaqueBlack, unnormalizedCoordinates: false, compareEnable: false,
                    compareOp: CompareOp.Never, mipmapMode: SamplerMipmapMode.Linear, mipLodBias: 0.0f, minLod: 0.0f,
                    maxLod: 0.0f
                );

                _vk.CreateSampler(_logicalDeviceProvider.LogicalDevice, samplerInfo, null, out var sampler);
                Sampler = sampler;
            }
        }
        
        public unsafe void CopyBufferToImage(Buffer src)
        {
            Debug.Assert(_layout == ImageLayout.TransferDstOptimal);
            _commandBufferFactory.RunSingleTime
            (
                _transferQueueProvider.TransferQueueIndex, _transferQueueProvider.TransferQueue,
                cmd =>
                {
                    var region = new BufferImageCopy
                    (
                        bufferOffset: 0, bufferRowLength: 0, bufferImageHeight: 0,
                        imageSubresource: new ImageSubresourceLayers
                            (aspectMask: _aspectFlags, mipLevel: 0, baseArrayLayer: 0, layerCount: 1),
                        imageOffset: new Offset3D(0, 0, 0), imageExtent: new(_width, _height, 1)
                    );
                    
                    _vk.CmdCopyBufferToImage(cmd, src, Image, ImageLayout.TransferDstOptimal, 1, &region);
                }
            );
        }
        
        public unsafe void TransitionImageLayout(ImageLayout @new)
        {
            if (_layout == @new)
                return;
            
            uint srcFamilyIndex;
            uint dstFamilyIndex;
            PipelineStageFlags sourceStage;
            PipelineStageFlags destinationStage;
            AccessFlags srcAccessMask;
            AccessFlags dstAccessMask;
            Queue srcQueue;
            Queue dstQueue;
            
            switch (@new)
            {
                case ImageLayout.TransferDstOptimal when _layout is ImageLayout.Undefined:
                    srcAccessMask = 0;
                    dstAccessMask = AccessFlags.AccessTransferWriteBit;

                    sourceStage = PipelineStageFlags.PipelineStageTopOfPipeBit;
                    destinationStage = PipelineStageFlags.PipelineStageTransferBit;

                    srcFamilyIndex = Vk.QueueFamilyExternal;
                    srcQueue = default;
                    dstFamilyIndex = _transferQueueProvider.TransferQueueIndex;
                    dstQueue = _transferQueueProvider.TransferQueue;
                    break;
                case ImageLayout.ShaderReadOnlyOptimal when _layout is ImageLayout.TransferDstOptimal:
                    srcAccessMask = AccessFlags.AccessTransferWriteBit;
                    dstAccessMask = AccessFlags.AccessShaderReadBit;

                    sourceStage = PipelineStageFlags.PipelineStageTransferBit;
                    destinationStage = PipelineStageFlags.PipelineStageFragmentShaderBit;

                    srcFamilyIndex = _transferQueueProvider.TransferQueueIndex;
                    srcQueue = _transferQueueProvider.TransferQueue;
                    dstFamilyIndex = _graphicsQueueProvider.GraphicsQueueIndex;
                    dstQueue = _graphicsQueueProvider.GraphicsQueue;
                    break;
                case ImageLayout.DepthStencilAttachmentOptimal when _layout is ImageLayout.Undefined:
                    srcAccessMask = 0;
                    dstAccessMask = AccessFlags.AccessDepthStencilAttachmentReadBit | AccessFlags.AccessDepthStencilAttachmentWriteBit;

                    sourceStage = PipelineStageFlags.PipelineStageTopOfPipeBit;
                    destinationStage = PipelineStageFlags.PipelineStageEarlyFragmentTestsBit;

                    srcFamilyIndex = Vk.QueueFamilyExternal;
                    srcQueue = default;
                    dstFamilyIndex = _graphicsQueueProvider.GraphicsQueueIndex;
                    dstQueue = _graphicsQueueProvider.GraphicsQueue;
                    break;
                default:
                    throw new Exception("Could not find transition combination");
            }

            if (srcFamilyIndex != dstFamilyIndex && srcFamilyIndex != Vk.QueueFamilyExternal)
            {
                _commandBufferFactory.RunSingleTime
                (
                    srcFamilyIndex, srcQueue, cmd =>
                    {
                        var releaseBarrier = new ImageMemoryBarrier
                        (
                            oldLayout: _layout, newLayout: _layout, srcQueueFamilyIndex: srcFamilyIndex,
                            dstQueueFamilyIndex: dstFamilyIndex, image: Image,
                            subresourceRange: new ImageSubresourceRange
                            (
                                aspectMask: _aspectFlags, baseMipLevel: 0, levelCount: 1,
                                baseArrayLayer: 0, layerCount: 1
                            ), srcAccessMask: srcAccessMask, dstAccessMask: srcAccessMask
                        );

                        _vk.CmdPipelineBarrier(cmd,
                            sourceStage, sourceStage,
                            0,
                            0, null,
                            0, null,
                            1, &releaseBarrier);
                    }
                );
            }

            _commandBufferFactory.RunSingleTime(dstFamilyIndex, dstQueue,
                cmd =>
                {
                    var barrier = new ImageMemoryBarrier
                    (
                        oldLayout: _layout, newLayout: @new, srcQueueFamilyIndex: srcFamilyIndex,
                        dstQueueFamilyIndex: dstFamilyIndex, image: Image,
                        subresourceRange: new ImageSubresourceRange
                        (
                            aspectMask: _aspectFlags, baseMipLevel: 0, levelCount: 1,
                            baseArrayLayer: 0, layerCount: 1
                        ), srcAccessMask: srcAccessMask, dstAccessMask: dstAccessMask
                    );

                    _vk.CmdPipelineBarrier(cmd,
                        sourceStage, destinationStage,
                        0, 
                        0, null,
                        0, null,
                        1, &barrier);
                });

            _layout = @new;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyImageView(_logicalDeviceProvider.LogicalDevice, ImageView, null);
            _vk.DestroyImage(_logicalDeviceProvider.LogicalDevice, Image, null);
            _vk.FreeMemory(_logicalDeviceProvider.LogicalDevice, Memory, null);
        }
    }
}
