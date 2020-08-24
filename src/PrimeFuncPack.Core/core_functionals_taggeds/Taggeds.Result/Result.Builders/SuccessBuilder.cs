#nullable enable

namespace PrimeFuncPack.Core.Result.Builders
{
    // Targeted for use in the Result factory methods only
    internal static class SuccessBuilder
    {
        public static SuccessBuilder<TSuccess> From<TSuccess>(in TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilder<TSuccess>.From(success);
    }
}
