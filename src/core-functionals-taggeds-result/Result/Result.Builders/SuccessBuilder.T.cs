#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    public sealed class SuccessBuilder<TSuccess>
    {
        private readonly TSuccess success;

        private SuccessBuilder(TSuccess success)
            =>
            this.success = success;

        internal static SuccessBuilder<TSuccess> Create(TSuccess success)
            =>
            new(success);

        public Result<TSuccess, TFailure> Build<TFailure>()
            where TFailure : struct
            =>
            success;
    }
}
