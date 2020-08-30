#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    public abstract class SuccessBuilder<TSuccess> where TSuccess : notnull
    {
        private readonly TSuccess success;

        private protected SuccessBuilder(in TSuccess success)
            =>
            this.success = success;

        public Result<TSuccess, TFailure> Build<TFailure>() where TFailure : notnull, new()
            =>
            Result<TSuccess, TFailure>.Success(success);
    }
}
