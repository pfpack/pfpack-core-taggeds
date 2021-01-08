#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    public readonly struct SuccessBuilder<TSuccess>
    {
        private readonly TSuccess success;

        internal SuccessBuilder(TSuccess success)
            =>
            this.success = success;

        public Result<TSuccess, TFailure> With<TFailure>() where TFailure : struct
            =>
            success;
    }
}
