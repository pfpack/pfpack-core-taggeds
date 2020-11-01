#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    public readonly struct FailureBuilder<TFailure>
        where TFailure : struct
    {
        private readonly TFailure failure;

        private FailureBuilder(in TFailure failure)
            =>
            this.failure = failure;

        internal static FailureBuilder<TFailure> Create(in TFailure failure)
            =>
            new FailureBuilder<TFailure>(failure);

        public Result<TSuccess, TFailure> Build<TSuccess>()
            where TSuccess : notnull
            =>
            Result<TSuccess, TFailure>.Failure(failure);
    }
}
