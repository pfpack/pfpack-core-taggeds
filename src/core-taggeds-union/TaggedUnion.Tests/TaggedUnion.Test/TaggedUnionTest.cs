using System;

namespace PrimeFuncPack.Core.Tests;

public sealed partial class TaggedUnionTest
{
    private const string First = "First";

    private const string Second = "Second";

    private static void AssertContains(
        string expectedSubstring,
        string? actual,
        StringComparison comparison = StringComparison.Ordinal)
    {
        ClassicAssert.NotNull(actual);
        ClassicAssert.True(actual!.Contains(expectedSubstring, comparison));
    }
}
