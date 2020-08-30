#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    public sealed class FailureBuilder<TFailure> where TFailure : notnull, new()
    {
        private readonly TFailure failure;

        private FailureBuilder(in TFailure failure)
            =>
            this.failure = failure;

        internal static FailureBuilder<TFailure> Create(in TFailure failure)
            =>
            new FailureBuilder<TFailure>(failure ?? throw new ArgumentNullException(nameof(failure)));

        public Result<TSuccess, TFailure> Build<TSuccess>() where TSuccess : notnull
            =>
            Result<TSuccess, TFailure>.Failure(failure);
    }
}
