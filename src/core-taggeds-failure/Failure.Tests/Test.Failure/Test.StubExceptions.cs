using System;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    private class StubToStringException : Exception
    {
        public const string MessageValue = "Stub Exception Message";

        public const string ToStringResult = "Stub Exception ToString";

        public override string Message => MessageValue;

        public override string ToString() => ToStringResult;
    }

    private class StubToStringFormattableException : StubToStringException, IFormattable
    {
        public const string ToStringResultFormatted = "Stub Exception ToString Formatted";

        public string ToString(string? format, IFormatProvider? formatProvider) => ToStringResultFormatted;
    }
}
