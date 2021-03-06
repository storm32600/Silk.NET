// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.OpenXR
{
    [NativeName("Name", "XrVulkanSwapchainFormatListCreateInfoKHR")]
    public unsafe partial struct VulkanSwapchainFormatListCreateInfoKHR
    {
        public VulkanSwapchainFormatListCreateInfoKHR
        (
            StructureType? type = StructureType.TypeVulkanSwapchainFormatListCreateInfoKhr,
            void* next = null,
            uint? viewFormatCount = null,
            uint* viewFormats = null
        ) : this()
        {
            if (type is not null)
            {
                Type = type.Value;
            }

            if (next is not null)
            {
                Next = next;
            }

            if (viewFormatCount is not null)
            {
                ViewFormatCount = viewFormatCount.Value;
            }

            if (viewFormats is not null)
            {
                ViewFormats = viewFormats;
            }
        }

/// <summary></summary>
        [NativeName("Type", "XrStructureType")]
        [NativeName("Type.Name", "XrStructureType")]
        [NativeName("Name", "type")]
        public StructureType Type;
/// <summary></summary>
        [NativeName("Type", "void*")]
        [NativeName("Type.Name", "void")]
        [NativeName("Name", "next")]
        public void* Next;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "viewFormatCount")]
        public uint ViewFormatCount;
/// <summary></summary>
        [NativeName("Type", "VkFormat*")]
        [NativeName("Type.Name", "VkFormat")]
        [NativeName("Name", "viewFormats")]
        public uint* ViewFormats;
    }
}
