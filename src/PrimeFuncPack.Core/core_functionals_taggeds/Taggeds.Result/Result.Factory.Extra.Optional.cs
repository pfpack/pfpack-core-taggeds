#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial class Result
    {
        public static Result<TSuccess, Unit> Present<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilderImpl<TSuccess>.Create(success);

        public static Result<TSuccess, Unit> Absent<TSuccess>() where TSuccess : notnull
            =>
            FailureBuilderImpl<Unit>.Create(default);
    }
}
