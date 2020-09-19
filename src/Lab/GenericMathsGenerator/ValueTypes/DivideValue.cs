﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

namespace GenericMathsGenerator
{
    public class DivideValue : BinaryOperatorValue
    {
        protected override float Process(float left, float right) => left / right;
        protected override string OpStr => "/";
    }
}