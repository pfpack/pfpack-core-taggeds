#nullable enable

using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.DependencyPipeline.Tests.TestEntities
{
    internal static class TestEntityTestData
    {
        public static IEnumerable<object?[]> RefTypeTestSource
            =>
            new[]
            {
                new RefType(),
                new RefType
                {
                    Id = GenerateInteger()
                },
                null
            }
            .Select(
                value => new object?[] { value });

        public static IEnumerable<object[]> StructTypeTestSource
            =>
            new[]
            {
                new StructType(),
                new StructType
                {
                    Text = GenerateText()
                },
                default
            }
            .Select(
                value => new object[] { value });
    }
}
