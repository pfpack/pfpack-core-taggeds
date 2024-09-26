using System;
using System.Threading.Tasks;

namespace System;

partial struct SuccessBuilder<TSuccess>
{
    public Result<TSuccess, TFailure> With<TFailure>()
        where TFailure : struct
        =>
        new(success);

    // TODO: Add the tests
    public Task<Result<TSuccess, TFailure>> WithAsync<TFailure>()
        where TFailure : struct
        =>
        Task.FromResult<Result<TSuccess, TFailure>>(new(success));

    // TODO: Add the tests
    public ValueTask<Result<TSuccess, TFailure>> WithValueAsync<TFailure>()
        where TFailure : struct
        =>
        ValueTask.FromResult<Result<TSuccess, TFailure>>(new(success));
}
