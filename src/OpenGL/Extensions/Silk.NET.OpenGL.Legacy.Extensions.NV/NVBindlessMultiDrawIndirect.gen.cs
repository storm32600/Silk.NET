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
using Silk.NET.OpenGL.Legacy;
using Extension = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.OpenGL.Legacy.Extensions.NV
{
    [Extension("NV_bindless_multi_draw_indirect")]
    public unsafe partial class NVBindlessMultiDrawIndirect : NativeExtension<GL>
    {
        public const string ExtensionName = "NV_bindless_multi_draw_indirect";
        [NativeApi(EntryPoint = "glMultiDrawArraysIndirectBindlessNV")]
        public unsafe partial void MultiDrawArraysIndirectBindles([Flow(FlowDirection.In)] NV mode, [Flow(FlowDirection.In)] void* indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount);

        [NativeApi(EntryPoint = "glMultiDrawArraysIndirectBindlessNV")]
        public partial void MultiDrawArraysIndirectBindles<T0>([Flow(FlowDirection.In)] NV mode, [Flow(FlowDirection.In)] in T0 indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount) where T0 : unmanaged;

        [NativeApi(EntryPoint = "glMultiDrawArraysIndirectBindlessNV")]
        public unsafe partial void MultiDrawArraysIndirectBindles([Flow(FlowDirection.In)] PrimitiveType mode, [Flow(FlowDirection.In)] void* indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount);

        [NativeApi(EntryPoint = "glMultiDrawArraysIndirectBindlessNV")]
        public partial void MultiDrawArraysIndirectBindles<T0>([Flow(FlowDirection.In)] PrimitiveType mode, [Flow(FlowDirection.In)] in T0 indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount) where T0 : unmanaged;

        [NativeApi(EntryPoint = "glMultiDrawElementsIndirectBindlessNV")]
        public unsafe partial void MultiDrawElementsIndirectBindles([Flow(FlowDirection.In)] NV mode, [Flow(FlowDirection.In)] NV type, [Flow(FlowDirection.In)] void* indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount);

        [NativeApi(EntryPoint = "glMultiDrawElementsIndirectBindlessNV")]
        public partial void MultiDrawElementsIndirectBindles<T0>([Flow(FlowDirection.In)] NV mode, [Flow(FlowDirection.In)] NV type, [Flow(FlowDirection.In)] in T0 indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount) where T0 : unmanaged;

        [NativeApi(EntryPoint = "glMultiDrawElementsIndirectBindlessNV")]
        public unsafe partial void MultiDrawElementsIndirectBindles([Flow(FlowDirection.In)] NV mode, [Flow(FlowDirection.In)] DrawElementsType type, [Flow(FlowDirection.In)] void* indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount);

        [NativeApi(EntryPoint = "glMultiDrawElementsIndirectBindlessNV")]
        public partial void MultiDrawElementsIndirectBindles<T0>([Flow(FlowDirection.In)] NV mode, [Flow(FlowDirection.In)] DrawElementsType type, [Flow(FlowDirection.In)] in T0 indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount) where T0 : unmanaged;

        [NativeApi(EntryPoint = "glMultiDrawElementsIndirectBindlessNV")]
        public unsafe partial void MultiDrawElementsIndirectBindles([Flow(FlowDirection.In)] PrimitiveType mode, [Flow(FlowDirection.In)] NV type, [Flow(FlowDirection.In)] void* indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount);

        [NativeApi(EntryPoint = "glMultiDrawElementsIndirectBindlessNV")]
        public partial void MultiDrawElementsIndirectBindles<T0>([Flow(FlowDirection.In)] PrimitiveType mode, [Flow(FlowDirection.In)] NV type, [Flow(FlowDirection.In)] in T0 indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount) where T0 : unmanaged;

        [NativeApi(EntryPoint = "glMultiDrawElementsIndirectBindlessNV")]
        public unsafe partial void MultiDrawElementsIndirectBindles([Flow(FlowDirection.In)] PrimitiveType mode, [Flow(FlowDirection.In)] DrawElementsType type, [Flow(FlowDirection.In)] void* indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount);

        [NativeApi(EntryPoint = "glMultiDrawElementsIndirectBindlessNV")]
        public partial void MultiDrawElementsIndirectBindles<T0>([Flow(FlowDirection.In)] PrimitiveType mode, [Flow(FlowDirection.In)] DrawElementsType type, [Flow(FlowDirection.In)] in T0 indirect, [Flow(FlowDirection.In)] uint drawCount, [Flow(FlowDirection.In)] uint stride, [Flow(FlowDirection.In)] int vertexBufferCount) where T0 : unmanaged;

        public NVBindlessMultiDrawIndirect(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

