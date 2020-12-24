#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    public sealed class SuccessBuilder<TSuccess>
        where TSuccess : notnull
    {
        private readonly TSuccess success;

        private SuccessBuilder(TSuccess success)
            =>
            this.success = success;

        internal static SuccessBuilder<TSuccess> Create(TSuccess success)
            =>
            new(success ?? throw new ArgumentNullException(nameof(success)));

        public Result<TSuccess, TFailure> Build<TFailure>()
            where TFailure : struct
            =>
            success;
    }
}
