#nullable enable

namespace PrimeFuncPack.Core.Result.Builders
{
    // Not supposed for explicit use in a client code
    internal static class FailureBuilder
    {
        // Targeted for use in the Result factory methods only
        public static FailureBuilder<TFailure> From<TFailure>(in TFailure failure) where TFailure : notnull, new()
            =>
            FailureBuilder<TFailure>.From(failure);
    }
}
