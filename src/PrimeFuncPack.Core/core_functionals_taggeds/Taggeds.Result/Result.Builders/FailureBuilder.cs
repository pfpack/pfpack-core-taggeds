#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    public abstract class FailureBuilder<TFailure> where TFailure : notnull, new()
    {
        private readonly TFailure failure;

        private protected FailureBuilder(in TFailure failure)
            =>
            this.failure = failure;

        public Result<TSuccess, TFailure> Build<TSuccess>() where TSuccess : notnull
            =>
            Result<TSuccess, TFailure>.Failure(failure);
    }
}
