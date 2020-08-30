#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial class Result
    {
        public static SuccessBuilder<TSuccess> Success<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            ResultBuilder.Success(success);

        public static FailureBuilder<TFailure> Failure<TFailure>(TFailure failure) where TFailure : notnull, new()
            =>
            ResultBuilder.Failure(failure);

        public static Result<TSuccess, Unit> Present<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            ResultBuilder.Success(success);

        public static Result<TSuccess, Unit> Absent<TSuccess>() where TSuccess : notnull
            =>
            ResultBuilder.Failure<Unit>(default);

        public static Result<Unit, Unit> True()
            =>
            ResultBuilder.Success<Unit>(default);

        public static Result<Unit, Unit> False()
            =>
            ResultBuilder.Failure<Unit>(default);
    }
}
