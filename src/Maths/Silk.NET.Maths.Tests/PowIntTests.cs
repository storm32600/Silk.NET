﻿using Xunit;

namespace Silk.NET.Maths.Tests
{
    public class PowIntTests
    {
        [Fact]
        public void Powx0()
        {
            var a = 100;
            var b = 0;
            var expected = 1;
            Assert.Equal(expected, Scalar.Pow(a, b));
        }
        
        [Fact]
        public void Pow00()
        {
            var a = 0;
            var b = 0;
            var expected = 0;
            Assert.Equal(expected, Scalar.Pow(a, b));
        }
        
        [Fact]
        public void Pow12()
        {
            var a = 1;
            var b = 2;
            var expected = 1;
            Assert.Equal(expected, Scalar.Pow(a, b));
        }

        [Fact]
        public void Pow24()
        {
            var a = 2;
            var b = 4;
            var expected = 2 << 3;
            Assert.Equal(expected, Scalar.Pow(a, b));
        }
        
        [Fact]
        public void Pow2Minus4()
        {
            var a = 2;
            var b = -4;
            var expected = (int)(1f / (2 << 3));
            Assert.Equal(expected, Scalar.Pow(a, b));
        }
    }
}
