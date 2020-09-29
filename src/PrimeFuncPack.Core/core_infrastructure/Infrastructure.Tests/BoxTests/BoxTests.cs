#nullable enable

using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Infrastructure.Tests
{
    public sealed partial class BoxTests
    {
        private static IEnumerable<object?[]> RefTypeTestSource
            =>
            new[]
            {
                PlusFifteenIdRefType,
                null,
                ZeroIdRefType
            }
            .Select(v => new object?[] { v });
    }
}
