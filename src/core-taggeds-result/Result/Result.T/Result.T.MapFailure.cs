using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result<TSuccess, TResultFailure> MapFailure<TResultFailure>(
        Func<TFailure, TResultFailure> mapFailure)
        where TResultFailure : struct
    {
        _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

        return InternalFold<Result<TSuccess, TResultFailure>>(
            static value => value,
            value => mapFailure.Invoke(value));
    }

    public Task<Result<TSuccess, TResultFailure>> MapFailureAsync<TResultFailure>(
        Func<TFailure, Task<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
    {
        _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

        return InternalFold<Task<Result<TSuccess, TResultFailure>>>(
            static value => Task.FromResult<Result<TSuccess, TResultFailure>>(value),
            async value => await mapFailureAsync.Invoke(value).ConfigureAwait(false));
    }

    public ValueTask<Result<TSuccess, TResultFailure>> MapFailureValueAsync<TResultFailure>(
        Func<TFailure, ValueTask<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
    {
        _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));
            
        return InternalFold<ValueTask<Result<TSuccess, TResultFailure>>>(
            static value => ValueTask.FromResult<Result<TSuccess, TResultFailure>>(value),
            async value => await mapFailureAsync.Invoke(value).ConfigureAwait(false));
    }
}
