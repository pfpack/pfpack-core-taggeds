#nullable enable

namespace PrimeFuncPack.Core.Result.Builders
{
    internal static class ResultBuilder
    {
        public static SuccessBuilder<TSuccess> Success<TSuccess>(in TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilder<TSuccess>.Create(success);

        public static FailureBuilder<TFailure> Failure<TFailure>(in TFailure failure) where TFailure : notnull, new()
            =>
            FailureBuilder<TFailure>.Create(failure);
    }
}
