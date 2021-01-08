#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    public sealed class SuccessBuilder<TSuccess>
    {
        private readonly TSuccess success;

        internal SuccessBuilder(TSuccess success)
            =>
            this.success = success;

        public Result<TSuccess, TFailure> Build<TFailure>()
            where TFailure : struct
            =>
            success;
    }
}
