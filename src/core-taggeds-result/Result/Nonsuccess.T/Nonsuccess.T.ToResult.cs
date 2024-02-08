using System.Threading.Tasks;

namespace System;

partial struct Nonsuccess<TFailure>
{
    public Result<TSuccess, TFailure> ToResult<TSuccess>()
        =>
        new(failure);

    public Task<Result<TSuccess, TFailure>> ToResultAsync<TSuccess>()
        =>
        Task.FromResult<Result<TSuccess, TFailure>>(new(failure));

    public ValueTask<Result<TSuccess, TFailure>> ToResultValueAsync<TSuccess>()
        =>
        ValueTask.FromResult<Result<TSuccess, TFailure>>(new(failure));
}
