#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class OptionalTest
    {
        [Test]
        public void Absent_Value_ExpectAbsentIsTrue()
        {
            var actual = Optional<StructType>.Absent;
            Assert.True(actual.IsAbsent);
        }

        [Test]
        public void Absent_Value_ExpectPresentIsFalse()
        {
            var actual = Optional<StructType>.Absent;
            Assert.False(actual.IsPresent);
        }
    }
}
