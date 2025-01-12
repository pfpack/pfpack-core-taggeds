using System.Threading.Tasks;

namespace System;

partial struct SuccessBuilder<TSuccess>
{
    public Result<TSuccess, TFailure> With<TFailure>()
        where TFailure : struct
        =>
        new(success);

    // TODO: Add the tests and open the method
    internal Task<Result<TSuccess, TFailure>> WithAsync<TFailure>()
        where TFailure : struct
        =>
        Task.FromResult<Result<TSuccess, TFailure>>(new(success));

    // TODO: Add the tests and open the method
    internal ValueTask<Result<TSuccess, TFailure>> WithValueAsync<TFailure>()
        where TFailure : struct
        =>
        ValueTask.FromResult<Result<TSuccess, TFailure>>(new(success));
}
