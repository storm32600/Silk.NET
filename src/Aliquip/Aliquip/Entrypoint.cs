﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;
using Silk.NET.Windowing;

namespace Aliquip
{
    public static class Entrypoint
    {
        public static IServiceCollection AddAliquip(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IWindowProvider, WindowProvider>()
                .AddSingleton(provider => provider.GetRequiredService<IWindowProvider>().Window)
                .AddSingleton(provider => (IObservable<WindowResized>) provider.GetRequiredService<IWindowProvider>())
                .AddSingleton(provider => (IObservable<WindowStateChanged>) provider.GetRequiredService<IWindowProvider>())
                .AddHostedService(provider => provider.GetRequiredService<IWindowProvider>())
                .AddSingleton(Vk.GetApi())
                .AddSingleton<IInstanceProvider, InstanceProvider>()
#if DEBUG
                .AddSingleton<IDebugMessengerProvider, DebugMessengerProvider>()
#endif
                .AddSingleton<ISurfaceProvider, SurfaceProvider>()
                .AddSingleton<IColorspaceRater, ColorSpaceRater>()
                .AddSingleton<IFormatRater, FormatRater>()
                .AddSingleton<IPhysicalDeviceProvider, PhysicalDeviceProvider>()
                .AddSingleton((provider) =>
                    {
                        provider.GetRequiredService<Vk>()
                            .TryGetInstanceExtension
                                (provider.GetRequiredService<IInstanceProvider>().Instance, out KhrSurface ext);
                        return ext;
                    }
                )
                .AddSingleton<ISwapchainSupportProvider, SwapchainSupportProvider>()
                .AddSingleton<IQueueFamilyProvider, QueueFamilyProvider>()
                .AddSingleton<LogicalDeviceProvider>()
                .AddSingleton(provider => (ILogicalDeviceProvider)provider.GetRequiredService<LogicalDeviceProvider>())
                .AddSingleton(provider => (IGraphicsQueueProvider)provider.GetRequiredService<LogicalDeviceProvider>())
                .AddSingleton(provider => (IPresentQueueProvider)provider.GetRequiredService<LogicalDeviceProvider>())
                .AddSingleton((provider) =>
                    {
                        provider.GetRequiredService<Vk>()
                            .TryGetDeviceExtension
                                (provider.GetRequiredService<IInstanceProvider>().Instance, provider.GetRequiredService<ILogicalDeviceProvider>().LogicalDevice, out KhrSwapchain ext);
                        return ext;
                    }
                )
                .AddSingleton<ISwapchainProvider, SwapchainProvider>()
                .AddSingleton<IImageViewProvider, ImageViewProvider>()
                .AddSingleton<IRenderPassProvider, RenderPassProvider>()
                .AddSingleton<IPipelineLayoutProvider, PipelineLayoutProvider>()
                .AddSingleton<IGraphicsPipelineProvider, GraphicsPipelineProvider>()
                .AddSingleton<IFramebufferProvider, FramebufferProvider>()
                .AddSingleton<ICommandPoolProvider, CommandPoolProvider>()
                .AddSingleton<ICommandBufferProvider, CommandBufferProvider>()
                .AddHostedService<DrawFrameService>()
                .AddSingleton<IResourceProvider, ResourceProvider>()
                ;
        }
    }
}