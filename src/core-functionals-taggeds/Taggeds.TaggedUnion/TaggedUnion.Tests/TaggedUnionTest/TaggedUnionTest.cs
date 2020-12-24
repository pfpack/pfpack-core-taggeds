#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    public sealed partial class TaggedUnionTest
    {
        private const string First = "first";

        private const string Second = "second";

        private static void AssertContainsFirst(
            string expectedSubString,
            string? actual)
        {
            Assert.NotNull(actual);
            Assert.True(actual!.Contains(expectedSubString, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
