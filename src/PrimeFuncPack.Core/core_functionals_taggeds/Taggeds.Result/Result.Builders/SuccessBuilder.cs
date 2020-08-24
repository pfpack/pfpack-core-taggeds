#nullable enable

namespace PrimeFuncPack.Core.Result.Builders
{
    // Not supposed for explicit use in a client code
    internal static class SuccessBuilder
    {
        // Targeted for use in the Result factory methods only
        public static SuccessBuilder<TSuccess> From<TSuccess>(in TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilder<TSuccess>.From(success);
    }
}
