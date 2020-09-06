#nullable enable

using System;
using System.Threading.Tasks;

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

        public Task<Result<TSuccess, TFailure>> BuildAsync<TSuccess>() where TSuccess : notnull
            =>
            Task.FromResult(
                Result<TSuccess, TFailure>.Failure(failure));

        public ValueTask<Result<TSuccess, TFailure>> BuildValueAsync<TSuccess>() where TSuccess : notnull
            =>
            ValueTask.FromResult(
                Result<TSuccess, TFailure>.Failure(failure));
    }
}
