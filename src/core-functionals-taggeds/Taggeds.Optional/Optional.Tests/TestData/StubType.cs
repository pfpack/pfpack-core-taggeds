#nullable enable

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    internal sealed class StubType
    {
        private readonly string? toStringValue;

        public StubType(string? toStringValue)
            => this.toStringValue = toStringValue;

        public override string? ToString()
            => toStringValue;
    }
}
