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

namespace Silk.NET.OpenGL.Legacy.Extensions.ARB
{
    public static class ArbClEventOverloads
    {
        public static unsafe nint CreateSyncFromCLevent(this ArbClEvent thisApi, [Flow(FlowDirection.Out)] nint* context, [Flow(FlowDirection.Out)] Span<nint> @event, [Flow(FlowDirection.In)] uint flags)
        {
            // SpanOverloader
            return thisApi.CreateSyncFromCLevent(context, out @event.GetPinnableReference(), flags);
        }

        public static unsafe nint CreateSyncFromCLevent(this ArbClEvent thisApi, [Flow(FlowDirection.Out)] Span<nint> context, [Flow(FlowDirection.Out)] nint* @event, [Flow(FlowDirection.In)] uint flags)
        {
            // SpanOverloader
            return thisApi.CreateSyncFromCLevent(out context.GetPinnableReference(), @event, flags);
        }

        public static unsafe nint CreateSyncFromCLevent(this ArbClEvent thisApi, [Flow(FlowDirection.Out)] Span<nint> context, [Flow(FlowDirection.Out)] Span<nint> @event, [Flow(FlowDirection.In)] uint flags)
        {
            // SpanOverloader
            return thisApi.CreateSyncFromCLevent(out context.GetPinnableReference(), out @event.GetPinnableReference(), flags);
        }

    }
}

