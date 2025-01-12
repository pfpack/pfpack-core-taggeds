using System.Threading.Tasks;

namespace System;

partial struct FailureBuilder<TFailure>
{
    public Result<TSuccess, TFailure> With<TSuccess>()
        =>
        new(failure);

    // TODO: Add the tests and open the method
    internal Task<Result<TSuccess, TFailure>> WithAsync<TSuccess>()
        =>
        Task.FromResult<Result<TSuccess, TFailure>>(new(failure));

    // TODO: Add the tests and open the method
    internal ValueTask<Result<TSuccess, TFailure>> WithValueAsync<TSuccess>()
        =>
        ValueTask.FromResult<Result<TSuccess, TFailure>>(new(failure));
}
