#nullable enable

using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.Tests
{
    internal static class TestEntityDateGenerator
    {
        public static IEnumerable<object?[]> RefTypeTestSource
            =>
            new[]
            {
                GenerateRefType(),
                GenerateRefType(),
                null
            }
            .Select(
                value => new object?[] { value });

        public static IEnumerable<object[]> StructTypeTestSource
            =>
            new[]
            {
                GenerateStructType(),
                GenerateStructType(),
                default
            }
            .Select(
                value => new object[] { value });

        public static RefType GenerateRefType()
            =>
            new RefType
            {
                Id = GenerateInteger()
            };

        public static StructType GenerateStructType()
            =>
            new StructType
            {
                Text = GenerateText()
            };
    }
}
