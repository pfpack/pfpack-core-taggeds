#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class FilterNotNullOptionalExtensionsTest
    {
        [Test]
        public void FilterNotNull_Struct_SourceValueIsNotNull_ExpectSource()
        {
            var source = Optional<StructType?>.Present(default(StructType));

            var actual = source.FilterNotNull();
            Assert.AreEqual(source.OrThrow()!.Value, actual.OrThrow());
        }

        [Test]
        public void FilterNotNull_SourceValueIsNull_ExpectAbsent()
        {
            var source = Optional<RefType?>.Present(null);

            var actual = source.FilterNotNull();
            var expected = Optional<RefType?>.Absent;

            Assert.AreEqual(expected, actual);
        }
    }
}
