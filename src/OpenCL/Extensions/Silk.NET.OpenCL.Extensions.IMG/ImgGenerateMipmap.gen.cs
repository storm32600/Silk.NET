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
using Silk.NET.OpenCL;
using Extension = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.OpenCL.Extensions.IMG
{
    [Extension("IMG_generate_mipmap")]
    public unsafe partial class ImgGenerateMipmap : NativeExtension<CL>
    {
        public const string ExtensionName = "IMG_generate_mipmap";
        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] nuint* array_region, [Flow(FlowDirection.In)] nuint* mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] nint* event_wait_list, [Flow(FlowDirection.Out)] nint* @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] nuint* array_region, [Flow(FlowDirection.In)] nuint* mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] nint* event_wait_list, [Flow(FlowDirection.Out)] out nint @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] nuint* array_region, [Flow(FlowDirection.In)] nuint* mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] in nint event_wait_list, [Flow(FlowDirection.Out)] nint* @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] nuint* array_region, [Flow(FlowDirection.In)] nuint* mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] in nint event_wait_list, [Flow(FlowDirection.Out)] out nint @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] nuint* array_region, [Flow(FlowDirection.In)] in nuint mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] nint* event_wait_list, [Flow(FlowDirection.Out)] nint* @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] nuint* array_region, [Flow(FlowDirection.In)] in nuint mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] nint* event_wait_list, [Flow(FlowDirection.Out)] out nint @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] nuint* array_region, [Flow(FlowDirection.In)] in nuint mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] in nint event_wait_list, [Flow(FlowDirection.Out)] nint* @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] nuint* array_region, [Flow(FlowDirection.In)] in nuint mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] in nint event_wait_list, [Flow(FlowDirection.Out)] out nint @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] in nuint array_region, [Flow(FlowDirection.In)] nuint* mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] nint* event_wait_list, [Flow(FlowDirection.Out)] nint* @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] in nuint array_region, [Flow(FlowDirection.In)] nuint* mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] nint* event_wait_list, [Flow(FlowDirection.Out)] out nint @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] in nuint array_region, [Flow(FlowDirection.In)] nuint* mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] in nint event_wait_list, [Flow(FlowDirection.Out)] nint* @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] in nuint array_region, [Flow(FlowDirection.In)] nuint* mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] in nint event_wait_list, [Flow(FlowDirection.Out)] out nint @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] in nuint array_region, [Flow(FlowDirection.In)] in nuint mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] nint* event_wait_list, [Flow(FlowDirection.Out)] nint* @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] in nuint array_region, [Flow(FlowDirection.In)] in nuint mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] nint* event_wait_list, [Flow(FlowDirection.Out)] out nint @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public unsafe partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] in nuint array_region, [Flow(FlowDirection.In)] in nuint mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] in nint event_wait_list, [Flow(FlowDirection.Out)] nint* @event);

        [NativeApi(EntryPoint = "clEnqueueGenerateMipmapIMG")]
        public partial int EnqueueGenerateMipmap([Flow(FlowDirection.In)] nint command_queue, [Flow(FlowDirection.In)] nint src_image, [Flow(FlowDirection.In)] nint dst_image, [Flow(FlowDirection.In)] IMG mipmap_filter_mode, [Flow(FlowDirection.In)] in nuint array_region, [Flow(FlowDirection.In)] in nuint mip_region, [Flow(FlowDirection.In)] uint num_events_in_wait_list, [Flow(FlowDirection.In)] in nint event_wait_list, [Flow(FlowDirection.Out)] out nint @event);

        public ImgGenerateMipmap(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

