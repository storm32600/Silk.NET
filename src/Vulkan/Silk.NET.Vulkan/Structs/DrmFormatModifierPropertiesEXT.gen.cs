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

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkDrmFormatModifierPropertiesEXT")]
    public unsafe partial struct DrmFormatModifierPropertiesEXT
    {
        public DrmFormatModifierPropertiesEXT
        (
            ulong? drmFormatModifier = null,
            uint? drmFormatModifierPlaneCount = null,
            FormatFeatureFlags? drmFormatModifierTilingFeatures = null
        ) : this()
        {
            if (drmFormatModifier is not null)
            {
                DrmFormatModifier = drmFormatModifier.Value;
            }

            if (drmFormatModifierPlaneCount is not null)
            {
                DrmFormatModifierPlaneCount = drmFormatModifierPlaneCount.Value;
            }

            if (drmFormatModifierTilingFeatures is not null)
            {
                DrmFormatModifierTilingFeatures = drmFormatModifierTilingFeatures.Value;
            }
        }

/// <summary></summary>
        [NativeName("Type", "uint64_t")]
        [NativeName("Type.Name", "uint64_t")]
        [NativeName("Name", "drmFormatModifier")]
        public ulong DrmFormatModifier;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "drmFormatModifierPlaneCount")]
        public uint DrmFormatModifierPlaneCount;
/// <summary></summary>
        [NativeName("Type", "VkFormatFeatureFlags")]
        [NativeName("Type.Name", "VkFormatFeatureFlags")]
        [NativeName("Name", "drmFormatModifierTilingFeatures")]
        public FormatFeatureFlags DrmFormatModifierTilingFeatures;
    }
}
