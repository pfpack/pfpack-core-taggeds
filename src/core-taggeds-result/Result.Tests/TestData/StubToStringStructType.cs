#nullable enable

namespace PrimeFuncPack.Core.Tests
{
    internal readonly struct StubToStringStructType
    {
        private readonly string? toStringValue;

        public StubToStringStructType(
            string? toStringValue)
            =>
            this.toStringValue = toStringValue;

        public override string? ToString()
            => toStringValue;
    }
}