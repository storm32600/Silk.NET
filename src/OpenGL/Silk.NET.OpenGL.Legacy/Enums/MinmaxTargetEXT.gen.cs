// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.OpenGL.Legacy
{
    [NativeName("Name", "MinmaxTargetEXT")]
    public enum MinmaxTargetEXT : int
    {
        [NativeName("Name", "GL_MINMAX")]
        Minmax = 0x802E,
        [NativeName("Name", "GL_MINMAX_EXT")]
        MinmaxExt = 0x802E,
    }
}
