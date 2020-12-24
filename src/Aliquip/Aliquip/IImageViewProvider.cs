﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    public interface IImageViewProvider : IDisposable
    {
        ImageView[] ImageViews { get; }
        void RecreateImageViews();
    }
}
