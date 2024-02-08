using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core;

partial struct FailureBuilder<TFailure>
{
    public Result<TSuccess, TFailure> With<TSuccess>()
        =>
        new(failure);

    // TODO: Add the tests
    public Task<Result<TSuccess, TFailure>> WithAsync<TSuccess>()
        =>
        Task.FromResult<Result<TSuccess, TFailure>>(new(failure));

    // TODO: Add the tests
    public ValueTask<Result<TSuccess, TFailure>> WithValueAsync<TSuccess>()
        =>
        ValueTask.FromResult<Result<TSuccess, TFailure>>(new(failure));
}
