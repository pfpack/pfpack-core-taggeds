#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    partial struct FailureBuilder<TFailure>
    {
        // Implement the equality explicitly instead of the default struct equality
        // for the performance purposes.
        // Not supposed for explicit use in a client code

        public override bool Equals(object? obj)
            =>
            obj is FailureBuilder<TFailure> other &&
            builderObj == other.builderObj;

        public override int GetHashCode() => HashCode.Combine(
            typeof(FailureBuilder<TFailure>),
            builderObj);
    }
}
