#nullable enable

namespace PrimeFuncPack.Core.Result.Builders
{
    // Targeted for use in the Result factory methods only
    internal static class FailureBuilder
    {
        public static FailureBuilder<TFailure> From<TFailure>(in TFailure failure) where TFailure : notnull, new()
            =>
            FailureBuilder<TFailure>.From(failure);
    }
}
