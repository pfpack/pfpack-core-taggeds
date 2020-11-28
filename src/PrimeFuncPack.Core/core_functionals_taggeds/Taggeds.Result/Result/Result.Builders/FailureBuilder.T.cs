#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    public readonly struct FailureBuilder<TFailure> where TFailure : struct
    {
        private readonly TFailure failure;

        private FailureBuilder(in TFailure failure)
            =>
            this.failure = failure;

        internal static FailureBuilder<TFailure> Create(in TFailure failure)
            =>
            new(failure);

        public Result<TSuccess, TFailure> Build<TSuccess>() where TSuccess : notnull
            =>
            failure;
    }
}
