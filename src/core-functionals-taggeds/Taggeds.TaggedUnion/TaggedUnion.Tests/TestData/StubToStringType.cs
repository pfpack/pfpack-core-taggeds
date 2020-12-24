﻿#nullable enable

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    internal sealed class StubToStringType
    {
        private readonly string? toStringValue;

        public StubToStringType(
            string? toStringValue)
            =>
            this.toStringValue = toStringValue;

        public override string? ToString()
            => toStringValue;
    }
}
