using System.Threading.Tasks;

namespace System;

partial struct Success<TSuccess>
{
    public Result<TSuccess, TFailure> ToResult<TFailure>()
        where TFailure : struct
        =>
        new(success);

    public Task<Result<TSuccess, TFailure>> ToResultAsync<TFailure>()
        where TFailure : struct
        =>
        Task.FromResult<Result<TSuccess, TFailure>>(new(success));

    public ValueTask<Result<TSuccess, TFailure>> ToResultValueAsync<TFailure>()
        where TFailure : struct
        =>
        ValueTask.FromResult<Result<TSuccess, TFailure>>(new(success));
}
