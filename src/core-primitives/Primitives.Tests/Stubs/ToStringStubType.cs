#nullable enable

namespace PrimeFuncPack.Core.Primitives.Tests
{
    internal sealed class ToStringStubType
    {
        private readonly string? toStringValue;

        public ToStringStubType(string? toStringValue)
            => this.toStringValue = toStringValue;

        public override string? ToString()
            => toStringValue;
    }
}
