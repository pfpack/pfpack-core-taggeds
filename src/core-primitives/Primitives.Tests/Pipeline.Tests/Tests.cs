#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    public sealed partial class PipelineTests
    {
        private static IEnumerable<object?[]> ValueTestSource
            =>
            SourceValues.Select(v => new object?[] { v });

        private static IReadOnlyCollection<object?> SourceValues
            =>
            new object?[]
            {
                null,
                "Some String",
                string.Empty,
                new DateTime(2020, 09, 25),
                (int?)15,
                new object(),
                new { Id = 1, Text = "Some Text" }
            };
    }
}
