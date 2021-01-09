#nullable enable

using PrimeFuncPack.Core;

namespace System
{
    partial class Result
    {
        public static SuccessBuilder<TSuccess> Success<TSuccess>(TSuccess success)
            =>
            new(success);

        public static FailureBuilder<TFailure> Failure<TFailure>(TFailure failure) where TFailure : struct
            =>
            new(failure);
    }
}
