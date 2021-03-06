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
    [NativeName("Name", "VkPhysicalDeviceConservativeRasterizationPropertiesEXT")]
    public unsafe partial struct PhysicalDeviceConservativeRasterizationPropertiesEXT
    {
        public PhysicalDeviceConservativeRasterizationPropertiesEXT
        (
            StructureType? sType = StructureType.PhysicalDeviceConservativeRasterizationPropertiesExt,
            void* pNext = null,
            float? primitiveOverestimationSize = null,
            float? maxExtraPrimitiveOverestimationSize = null,
            float? extraPrimitiveOverestimationSizeGranularity = null,
            Bool32? primitiveUnderestimation = null,
            Bool32? conservativePointAndLineRasterization = null,
            Bool32? degenerateTrianglesRasterized = null,
            Bool32? degenerateLinesRasterized = null,
            Bool32? fullyCoveredFragmentShaderInputVariable = null,
            Bool32? conservativeRasterizationPostDepthCoverage = null
        ) : this()
        {
            if (sType is not null)
            {
                SType = sType.Value;
            }

            if (pNext is not null)
            {
                PNext = pNext;
            }

            if (primitiveOverestimationSize is not null)
            {
                PrimitiveOverestimationSize = primitiveOverestimationSize.Value;
            }

            if (maxExtraPrimitiveOverestimationSize is not null)
            {
                MaxExtraPrimitiveOverestimationSize = maxExtraPrimitiveOverestimationSize.Value;
            }

            if (extraPrimitiveOverestimationSizeGranularity is not null)
            {
                ExtraPrimitiveOverestimationSizeGranularity = extraPrimitiveOverestimationSizeGranularity.Value;
            }

            if (primitiveUnderestimation is not null)
            {
                PrimitiveUnderestimation = primitiveUnderestimation.Value;
            }

            if (conservativePointAndLineRasterization is not null)
            {
                ConservativePointAndLineRasterization = conservativePointAndLineRasterization.Value;
            }

            if (degenerateTrianglesRasterized is not null)
            {
                DegenerateTrianglesRasterized = degenerateTrianglesRasterized.Value;
            }

            if (degenerateLinesRasterized is not null)
            {
                DegenerateLinesRasterized = degenerateLinesRasterized.Value;
            }

            if (fullyCoveredFragmentShaderInputVariable is not null)
            {
                FullyCoveredFragmentShaderInputVariable = fullyCoveredFragmentShaderInputVariable.Value;
            }

            if (conservativeRasterizationPostDepthCoverage is not null)
            {
                ConservativeRasterizationPostDepthCoverage = conservativeRasterizationPostDepthCoverage.Value;
            }
        }

/// <summary></summary>
        [NativeName("Type", "VkStructureType")]
        [NativeName("Type.Name", "VkStructureType")]
        [NativeName("Name", "sType")]
        public StructureType SType;
/// <summary></summary>
        [NativeName("Type", "void*")]
        [NativeName("Type.Name", "void")]
        [NativeName("Name", "pNext")]
        public void* PNext;
/// <summary></summary>
        [NativeName("Type", "float")]
        [NativeName("Type.Name", "float")]
        [NativeName("Name", "primitiveOverestimationSize")]
        public float PrimitiveOverestimationSize;
/// <summary></summary>
        [NativeName("Type", "float")]
        [NativeName("Type.Name", "float")]
        [NativeName("Name", "maxExtraPrimitiveOverestimationSize")]
        public float MaxExtraPrimitiveOverestimationSize;
/// <summary></summary>
        [NativeName("Type", "float")]
        [NativeName("Type.Name", "float")]
        [NativeName("Name", "extraPrimitiveOverestimationSizeGranularity")]
        public float ExtraPrimitiveOverestimationSizeGranularity;
/// <summary></summary>
        [NativeName("Type", "VkBool32")]
        [NativeName("Type.Name", "VkBool32")]
        [NativeName("Name", "primitiveUnderestimation")]
        public Bool32 PrimitiveUnderestimation;
/// <summary></summary>
        [NativeName("Type", "VkBool32")]
        [NativeName("Type.Name", "VkBool32")]
        [NativeName("Name", "conservativePointAndLineRasterization")]
        public Bool32 ConservativePointAndLineRasterization;
/// <summary></summary>
        [NativeName("Type", "VkBool32")]
        [NativeName("Type.Name", "VkBool32")]
        [NativeName("Name", "degenerateTrianglesRasterized")]
        public Bool32 DegenerateTrianglesRasterized;
/// <summary></summary>
        [NativeName("Type", "VkBool32")]
        [NativeName("Type.Name", "VkBool32")]
        [NativeName("Name", "degenerateLinesRasterized")]
        public Bool32 DegenerateLinesRasterized;
/// <summary></summary>
        [NativeName("Type", "VkBool32")]
        [NativeName("Type.Name", "VkBool32")]
        [NativeName("Name", "fullyCoveredFragmentShaderInputVariable")]
        public Bool32 FullyCoveredFragmentShaderInputVariable;
/// <summary></summary>
        [NativeName("Type", "VkBool32")]
        [NativeName("Type.Name", "VkBool32")]
        [NativeName("Name", "conservativeRasterizationPostDepthCoverage")]
        public Bool32 ConservativeRasterizationPostDepthCoverage;
    }
}
