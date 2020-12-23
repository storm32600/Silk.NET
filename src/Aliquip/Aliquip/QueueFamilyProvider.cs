﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System.Collections.Generic;
using Silk.NET.Core;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;

namespace Aliquip
{
    internal sealed class QueueFamilyProvider : IQueueFamilyProvider
    {
        private readonly Vk _vk;
        private readonly KhrSurface _khrSurface;
        private readonly Dictionary<PhysicalDevice, QueueFamilyIndices> _queueFamilyIndices = new();
        private readonly SurfaceKHR _surface;

        public QueueFamilyProvider(Vk vk, KhrSurface khrSurface, ISurfaceProvider surfaceProvider)
        {
            _vk = vk;
            _khrSurface = khrSurface;
            _surface = surfaceProvider.Surface;
        }
        
        public unsafe QueueFamilyIndices FindQueueFamilyIndices(PhysicalDevice device)
        {
            if (_queueFamilyIndices.TryGetValue(device, out var res))
                return res;
            
            QueueFamilyIndices indices = default;

            uint queueFamilyCount = 0;
            _vk.GetPhysicalDeviceQueueFamilyProperties(device, ref queueFamilyCount, null);

            var pQueueFamilies = stackalloc QueueFamilyProperties[(int) queueFamilyCount];
            _vk.GetPhysicalDeviceQueueFamilyProperties(device, ref queueFamilyCount, pQueueFamilies);

            for (uint i = 0; i < queueFamilyCount; i++)
            {
                if ((pQueueFamilies[i].QueueFlags & QueueFlags.QueueGraphicsBit) != 0)
                    indices.GraphicsFamily = i;

                Bool32 presentSupport = default;
                _khrSurface.GetPhysicalDeviceSurfaceSupport(device, i, _surface, &presentSupport);

                if (presentSupport)
                {
                    indices.PresentFamily = i;
                }
                if (indices.IsComplete()) break;
            }

            _queueFamilyIndices[device] = indices;
            return indices;
        }
    }
}