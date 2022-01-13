using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result<TResultSuccess, TFailure> MapSuccess<TResultSuccess>(
        Func<TSuccess, TResultSuccess> mapSuccess)
    {
        _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

        return InnerFold<Result<TResultSuccess, TFailure>>(
            value => mapSuccess.Invoke(value),
            static value => value);
    }

    public Task<Result<TResultSuccess, TFailure>> MapSuccessAsync<TResultSuccess>(
        Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync)
    {
        _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));

        return InnerFold<Task<Result<TResultSuccess, TFailure>>>(
            async value => await mapSuccessAsync.Invoke(value).ConfigureAwait(false),
            static value => Task.FromResult<Result<TResultSuccess, TFailure>>(value));
    }

    public ValueTask<Result<TResultSuccess, TFailure>> MapSuccessValueAsync<TResultSuccess>(
        Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync)
    {
        _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
            
        return InnerFold<ValueTask<Result<TResultSuccess, TFailure>>>(
            async value => await mapSuccessAsync.Invoke(value).ConfigureAwait(false),
            static value => ValueTask.FromResult<Result<TResultSuccess, TFailure>>(value));
    }
}
