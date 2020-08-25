#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack.Core.Objects.Tests.TestData
{
    internal static class TestDataSource
    {
        public static IEnumerable<object[]> NotNullValueTestSource
            =>
            new[]
            {
                new RefType(),
                new object()
            }
            .Select(v => new[] { v });
    }
}
