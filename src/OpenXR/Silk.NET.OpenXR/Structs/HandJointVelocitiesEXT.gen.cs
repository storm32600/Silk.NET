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
    [NativeName("Name", "XrHandJointVelocitiesEXT")]
    public unsafe partial struct HandJointVelocitiesEXT
    {
        public HandJointVelocitiesEXT
        (
            StructureType? type = StructureType.TypeHandJointVelocitiesExt,
            void* next = null,
            uint? jointCount = null,
            HandJointVelocityEXT* jointVelocities = null
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

            if (jointCount is not null)
            {
                JointCount = jointCount.Value;
            }

            if (jointVelocities is not null)
            {
                JointVelocities = jointVelocities;
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
        [NativeName("Name", "jointCount")]
        public uint JointCount;
/// <summary></summary>
        [NativeName("Type", "XrHandJointVelocityEXT*")]
        [NativeName("Type.Name", "XrHandJointVelocityEXT")]
        [NativeName("Name", "jointVelocities")]
        public HandJointVelocityEXT* JointVelocities;
    }
}
