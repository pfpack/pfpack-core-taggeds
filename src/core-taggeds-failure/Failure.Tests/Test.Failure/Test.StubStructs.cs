using System;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    private readonly struct StubToStringStructFormattable : IFormattable
    {
        public const string ToStringResult = "Stub Struct ToString";

        public const string ToStringResultFormatted = "Stub Struct ToString Formatted";

        public override string ToString() => ToStringResult;

        public string ToString(string? format, IFormatProvider? formatProvider) => ToStringResultFormatted;
    }
}
