#nullable enable

using PrimeFuncPack.UnitTest.Data;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack.Core.Infrastructure.Tests
{
    public sealed partial class BoxTests
    {
        private static IEnumerable<object?[]> RefTypeTestSource
            =>
            new[]
            {
                new RefType(),
                null,
                new RefType
                {
                    Id = 21
                }
            }
            .Select(v => new object?[] { v });
    }
}
