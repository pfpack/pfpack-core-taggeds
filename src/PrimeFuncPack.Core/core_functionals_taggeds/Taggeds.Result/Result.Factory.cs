#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial class Result
    {
        public static SuccessBuilder<TSuccess> Success<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            ImplSuccessBuilder<TSuccess>.Create(success);

        public static FailureBuilder<TFailure> Failure<TFailure>(TFailure failure) where TFailure : notnull, new()
            =>
            ImplFailureBuilder<TFailure>.Create(failure);
    }
}
