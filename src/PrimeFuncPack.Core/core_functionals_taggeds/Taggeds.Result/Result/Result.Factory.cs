#nullable enable

using PrimeFuncPack.Core;

namespace System
{
    partial class Result
    {
        public static SuccessBuilder<TSuccess> Success<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilder<TSuccess>.Create(success);

        public static FailureBuilder<TFailure> Failure<TFailure>(TFailure failure) where TFailure : struct
            =>
            FailureBuilder<TFailure>.Create(failure);
    }
}
