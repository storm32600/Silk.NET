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

namespace Silk.NET.SDL
{
    [StructLayout(LayoutKind.Explicit)]
    [NativeName("Name", "__AnonymousRecord_SDL_gamecontroller_L84_C5")]
    public unsafe partial struct GameControllerBindValue
    {
        public GameControllerBindValue
        (
            int? button = null,
            int? axis = null,
            GameControllerHatValue? hat = null
        ) : this()
        {
            if (button is not null)
            {
                Button = button.Value;
            }

            if (axis is not null)
            {
                Axis = axis.Value;
            }

            if (hat is not null)
            {
                Hat = hat.Value;
            }
        }


        [FieldOffset(0)]
        [NativeName("Type", "int")]
        [NativeName("Type.Name", "int")]
        [NativeName("Name", "button")]
        public int Button;

        [FieldOffset(0)]
        [NativeName("Type", "int")]
        [NativeName("Type.Name", "int")]
        [NativeName("Name", "axis")]
        public int Axis;

        [FieldOffset(0)]
        [NativeName("Type", "struct (anonymous struct at build/submodules/SDL-mirror/include\\SDL_gamecontroller.h:88:9)")]
        [NativeName("Type.Name", "struct (anonymous struct at build/submodules/SDL-mirror/include\\SDL_gamecontroller.h:88:9)")]
        [NativeName("Name", "hat")]
        public GameControllerHatValue Hat;
    }
}
