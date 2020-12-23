﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using Silk.NET.Core.Native;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;

namespace Aliquip
{
    internal sealed class LogicalDeviceProvider : ILogicalDeviceProvider, IGraphicsQueueProvider, IPresentQueueProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly PhysicalDevice _physicalDevice;
        public Device LogicalDevice { get; }
        public Queue GraphicsQueue { get; }
        public Queue PresentQueue { get; }

        public unsafe LogicalDeviceProvider(IQueueFamilyProvider queueFamilyProvider, IPhysicalDeviceProvider physicalDeviceProvider, Vk vk)
        {
            _vk = vk;
            _physicalDevice = physicalDeviceProvider.Device;
            // TODO: dedup device extensions
            // (LogicalDeviceProvider & PhysicalDeviceProvider)
            var deviceExtensions = new List<string>();
            deviceExtensions.Add(KhrSwapchain.ExtensionName);
            
            QueueFamilyIndices indices = queueFamilyProvider.FindQueueFamilyIndices(_physicalDevice);

            List<uint> queuesToCreate = new();
            queuesToCreate.Add(indices.GraphicsFamily!.Value);
            queuesToCreate.Add(indices.PresentFamily!.Value);
            queuesToCreate = queuesToCreate.Distinct().ToList();

            var queueCreateInfos = stackalloc DeviceQueueCreateInfo[queuesToCreate.Count];
            var queuePriority = 1.0f;
            for (var i = 0; i < queuesToCreate.Count; i++)
            {
                queueCreateInfos[i] = new DeviceQueueCreateInfo
                    (queueFamilyIndex: queuesToCreate[i], queueCount: 1, pQueuePriorities: &queuePriority);
            }

            PhysicalDeviceFeatures deviceFeatures = new PhysicalDeviceFeatures();
            DeviceCreateInfo deviceCreateInfo = new DeviceCreateInfo
            (
                pQueueCreateInfos: queueCreateInfos,
                queueCreateInfoCount: (uint) queuesToCreate.Count,
                pEnabledFeatures: &deviceFeatures,
                enabledExtensionCount: (uint) deviceExtensions.Count,
                ppEnabledExtensionNames: deviceExtensions.Count > 0 ? (byte**) SilkMarshal.StringArrayToPtr(deviceExtensions) : default
                // these *should* be ignored by up-to-date versions, but we set them anyways.
                // TODO: Fix this up
                // enabledLayerCount: EnableValidationLayers ? (uint) ValidationLayers.Length : 0,
                // ppEnabledLayerNames: EnableValidationLayers
                //     ? (byte**) SilkMarshal.StringArrayToPtr(ValidationLayers)
                //     : default
            );

            _vk.CreateDevice(_physicalDevice, &deviceCreateInfo, null, out var logicalDevice).ThrowCode();
            LogicalDevice = logicalDevice;
            _vk.CurrentDevice = LogicalDevice;
            _vk.GetDeviceQueue(LogicalDevice, indices.GraphicsFamily!.Value, 0, out var graphicsQueue);
            GraphicsQueue = graphicsQueue;
            _vk.GetDeviceQueue(LogicalDevice, indices.PresentFamily!.Value, 0, out var presentQueue);
            PresentQueue = presentQueue;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyDevice(LogicalDevice, null);
        }
    }
}