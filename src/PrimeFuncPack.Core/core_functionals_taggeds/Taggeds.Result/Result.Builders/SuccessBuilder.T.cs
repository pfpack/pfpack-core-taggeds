#nullable enable

using System;
using System.Threading.Tasks;

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

        public Task<Result<TSuccess, TFailure>> BuildAsync<TFailure>() where TFailure : notnull, new()
            =>
            Task.FromResult(
                Result<TSuccess, TFailure>.Success(success));

        public ValueTask<Result<TSuccess, TFailure>> BuildValueAsync<TFailure>() where TFailure : notnull, new()
            =>
            ValueTask.FromResult(
                Result<TSuccess, TFailure>.Success(success));
    }
}
