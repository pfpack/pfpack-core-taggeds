#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    partial struct SuccessBuilder<TSuccess>
    {
        // Implement the equality explicitly instead of the default struct equality
        // for the performance purposes.
        // Not supposed for explicit use in a client code

        public override bool Equals(object? obj)
            =>
            obj is SuccessBuilder<TSuccess> other &&
            builderObj == other.builderObj;

        public override int GetHashCode() => HashCode.Combine(
            typeof(SuccessBuilder<TSuccess>),
            builderObj);
    }
}
