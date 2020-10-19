#nullable enable

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    internal sealed class StubToStringType
    {
        private readonly string? toStringValue;

        public StubToStringType(
            in string? toStringValue)
            =>
            this.toStringValue = toStringValue;

        public override string? ToString()
            => toStringValue;
    }
}
