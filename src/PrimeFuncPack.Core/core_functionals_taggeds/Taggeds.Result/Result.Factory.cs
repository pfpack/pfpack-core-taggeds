#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial class Result
    {
        public static SuccessBuilder<TSuccess> Success<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilder.From(success);

        public static FailureBuilder<TFailure> Failure<TFailure>(TFailure failure) where TFailure : notnull, new()
            =>
            FailureBuilder.From(failure);

        public static Result<TSuccess, Unit> True<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilder.From(success);

        public static Result<TSuccess, Unit> False<TSuccess>() where TSuccess : notnull
            =>
            FailureBuilder.From<Unit>(default);

        public static Result<Unit, Unit> True()
            =>
            SuccessBuilder.From<Unit>(default);

        public static Result<Unit, Unit> False()
            =>
            FailureBuilder.From<Unit>(default);
    }
}
