#nullable enable

namespace PrimeFuncPack.Core.Result.Builders
{
    internal static class SuccessBuilder
    {
        public static SuccessBuilder<TSuccess> From<TSuccess>(in TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilder<TSuccess>.From(success);
    }
}
