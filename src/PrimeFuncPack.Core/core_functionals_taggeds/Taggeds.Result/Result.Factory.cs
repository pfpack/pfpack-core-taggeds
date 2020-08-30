#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial class Result
    {
        public static SuccessBuilder<TSuccess> Success<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilder<TSuccess>.Create(success);

        public static FailureBuilder<TFailure> Failure<TFailure>(TFailure failure) where TFailure : notnull, new()
            =>
            FailureBuilder<TFailure>.Create(failure);

        public static Result<TSuccess, Unit> Present<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            Success(success);

        public static Result<TSuccess, Unit> Absent<TSuccess>() where TSuccess : notnull
            =>
            Failure<Unit>(default);

        public static Result<Unit, Unit> True()
            =>
            Success<Unit>(default);

        public static Result<Unit, Unit> False()
            =>
            Failure<Unit>(default);
    }
}
