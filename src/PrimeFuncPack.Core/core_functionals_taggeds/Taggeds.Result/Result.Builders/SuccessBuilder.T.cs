#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    public sealed class SuccessBuilder<TSuccess> where TSuccess : notnull
    {
        private readonly TSuccess success;

        private SuccessBuilder(in TSuccess success)
            =>
            this.success = success;

        internal static SuccessBuilder<TSuccess> Create(in TSuccess success)
            =>
            new SuccessBuilder<TSuccess>(success ?? throw new ArgumentNullException(nameof(success)));

        public Result<TSuccess, TFailure> Build<TFailure>() where TFailure : notnull, new()
            =>
            Result<TSuccess, TFailure>.Success(success);
    }
}
