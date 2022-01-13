using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    // Forward

    public Result<TNextSuccess, TNextFailure> Forward<TNextSuccess, TNextFailure>(
        Func<TSuccess, Result<TNextSuccess, TNextFailure>> nextFactory,
        Func<TFailure, TNextFailure> mapFailure)
        where TNextFailure : struct
    {
        _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));
        _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

        return InnerFold(nextFactory, failure => mapFailure.Invoke(failure));
    }

    public Result<TNextSuccess, TFailure> Forward<TNextSuccess>(
        Func<TSuccess, Result<TNextSuccess, TFailure>> nextFactory)
    {
        _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

        return InnerFold(nextFactory, failure => failure);
    }

    public Result<TSuccess, TFailure> Forward(
        Func<TSuccess, Result<TSuccess, TFailure>> nextFactory)
    {
        _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

        var @this = this;

        return InnerFold(nextFactory, _ => @this);
    }

    // Forward Async / Task

    public Task<Result<TNextSuccess, TNextFailure>> ForwardAsync<TNextSuccess, TNextFailure>(
        Func<TSuccess, Task<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
        Func<TFailure, Task<TNextFailure>> mapFailureAsync)
        where TNextFailure : struct
    {
        _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
        _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

        return InnerFold<Task<Result<TNextSuccess, TNextFailure>>>(
            nextFactoryAsync,
            async failure => await mapFailureAsync.Invoke(failure).ConfigureAwait(false));
    }

    public Task<Result<TNextSuccess, TFailure>> ForwardAsync<TNextSuccess>(
        Func<TSuccess, Task<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
    {
        _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

        return InnerFold(
            nextFactoryAsync,
            static failure => Task.FromResult<Result<TNextSuccess, TFailure>>(failure));
    }

    public Task<Result<TSuccess, TFailure>> ForwardAsync(
        Func<TSuccess, Task<Result<TSuccess, TFailure>>> nextFactoryAsync)
    {
        _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

        var @this = this;

        return InnerFold(nextFactoryAsync, _ => Task.FromResult(@this));
    }

    // Forward Async / ValueTask

    public ValueTask<Result<TNextSuccess, TNextFailure>> ForwardValueAsync<TNextSuccess, TNextFailure>(
        Func<TSuccess, ValueTask<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
        Func<TFailure, ValueTask<TNextFailure>> mapFailureAsync)
        where TNextFailure : struct
    {
        _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
        _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

        return InnerFold<ValueTask<Result<TNextSuccess, TNextFailure>>>(
            nextFactoryAsync,
            async failure => await mapFailureAsync.Invoke(failure).ConfigureAwait(false));
    }

    public ValueTask<Result<TNextSuccess, TFailure>> ForwardValueAsync<TNextSuccess>(
        Func<TSuccess, ValueTask<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
    {
        _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

        return InnerFold(
            nextFactoryAsync,
            static failure => ValueTask.FromResult<Result<TNextSuccess, TFailure>>(failure));
    }

    public ValueTask<Result<TSuccess, TFailure>> ForwardValueAsync(
        Func<TSuccess, ValueTask<Result<TSuccess, TFailure>>> nextFactoryAsync)
    {
        _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

        var @this = this;

        return InnerFold(nextFactoryAsync, _ => ValueTask.FromResult(@this));
    }
}
