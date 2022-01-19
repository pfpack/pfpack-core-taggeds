using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result<TResultSuccess, TResultFailure> Map<TResultSuccess, TResultFailure>(
        Func<TSuccess, TResultSuccess> mapSuccess,
        Func<TFailure, TResultFailure> mapFailure)
        where TResultFailure : struct
    {
        _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));
        _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

        return InnerFold<Result<TResultSuccess, TResultFailure>>(
            value => mapSuccess.Invoke(value),
            value => mapFailure.Invoke(value));
    }

    public Task<Result<TResultSuccess, TResultFailure>> MapAsync<TResultSuccess, TResultFailure>(
        Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync,
        Func<TFailure, Task<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
    {
        _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
        _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

        return InnerFold<Task<Result<TResultSuccess, TResultFailure>>>(
            async value => await mapSuccessAsync.Invoke(value).ConfigureAwait(false),
            async value => await mapFailureAsync.Invoke(value).ConfigureAwait(false));
    }

    public ValueTask<Result<TResultSuccess, TResultFailure>> MapValueAsync<TResultSuccess, TResultFailure>(
        Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync,
        Func<TFailure, ValueTask<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
    {
        _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
        _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

        return InnerFold<ValueTask<Result<TResultSuccess, TResultFailure>>>(
            async value => await mapSuccessAsync.Invoke(value).ConfigureAwait(false),
            async value => await mapFailureAsync.Invoke(value).ConfigureAwait(false));
    }
}
