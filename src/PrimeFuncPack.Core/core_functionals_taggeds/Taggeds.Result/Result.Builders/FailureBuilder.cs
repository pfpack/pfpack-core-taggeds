#nullable enable

namespace PrimeFuncPack.Core.Result.Builders
{
    internal static class FailureBuilder
    {
        public static FailureBuilder<TFailure> From<TFailure>(in TFailure failure) where TFailure : notnull, new()
            =>
            FailureBuilder<TFailure>.From(failure);
    }
}
