#nullable enable

using PrimeFuncPack.Core.Infrastructure.Tests.Stubs;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

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
                    Id = GenerateInteger()
                }
            }
            .Select(v => new object?[] { v });
    }
}
