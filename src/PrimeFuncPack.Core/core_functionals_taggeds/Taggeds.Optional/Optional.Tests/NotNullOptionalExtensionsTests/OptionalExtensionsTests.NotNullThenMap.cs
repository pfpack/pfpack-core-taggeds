#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class OptionalExtensionsTests
    {
        [Test]
        public void FilterNotNullThenMap_SourceValueIsNotNullRefType_ExpectNotNullableRefTypePresent()
        {
            var sourceValue = MinusFifteenIdRefType;
            var source = Optional<RefType?>.Present(sourceValue);

            var actual = source.FilterNotNullThenMap();
            var expected = Optional<RefType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullThenMap_SourceValueIsNullRefType_ExpectNotNullableRefTypeAbsent()
        {
            var source = Optional<RefType?>.Present(null);

            var actual = source.FilterNotNullThenMap();
            var expected = Optional<RefType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullThenMap_SourceValueIsNotNullStructType_ExpectNotNullableStructTypePresent()
        {
            var sourceValue = SomeTextStructType;
            var source = Optional<StructType?>.Present(sourceValue);

            var actual = source.FilterNotNullThenMap();
            var expected = Optional<StructType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullThenMap_SourceValueIsNullStructType_ExpectNotNullableStructTypeAbsent()
        {
            var source = Optional<StructType?>.Present(null);

            var actual = source.FilterNotNullThenMap();
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }
    }
}
