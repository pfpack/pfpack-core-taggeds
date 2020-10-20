#nullable enable

using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    internal static class TestDataSource
    {
        public static IEnumerable<object?[]> ObjectNullableTestSource
            =>
            new object?[]
            {
                null,
                new object(),
                MinusFifteen,
                PlusFifteenIdRefType,
                SomeTextStructType
            }
            .ToNullableTestSource();

        public static IEnumerable<object[]> TaggedUnionTestSource
            =>
            new[]
            {
                default(TaggedUnion<RefType, StructType>),
                TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType),
                TaggedUnion<RefType, StructType>.Second(SomeTextStructType)
            }
            .ToNotNullableTestSource();

        private static IEnumerable<object?[]> ToNullableTestSource(this IEnumerable<object?> source)
            =>
            source.Select(v => new[] { v });

        private static IEnumerable<object[]> ToNotNullableTestSource<T>(this IEnumerable<T> source)
            where T : notnull
            =>
            source.Select(v => new object[] { v });
    }
}
