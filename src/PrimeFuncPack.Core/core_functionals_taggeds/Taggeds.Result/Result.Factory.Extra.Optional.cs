#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial class Result
    {
        public static Result<TSuccess, Unit> Present<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            SuccessBuilder<TSuccess>.Create(success);

        public static Result<TSuccess, Unit> Absent<TSuccess>() where TSuccess : notnull
            =>
            FailureBuilder<Unit>.Create(default);
    }
}
