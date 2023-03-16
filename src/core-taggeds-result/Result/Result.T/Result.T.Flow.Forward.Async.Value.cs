using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public ValueTask<Result<TNextSuccess, TNextFailure>> ForwardValueAsync<TNextSuccess, TNextFailure>(
        Func<TSuccess, ValueTask<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
        Func<TFailure, ValueTask<TNextFailure>> mapFailureAsync)
        where TNextFailure : struct
        =>
        InnerForwardValueAsync(
            nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));

    public ValueTask<Result<TNextSuccess, TFailure>> ForwardValueAsync<TNextSuccess>(
        Func<TSuccess, ValueTask<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
        =>
        InnerForwardValueAsync(
            nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync)));

    public ValueTask<Result<TSuccess, TFailure>> ForwardValueAsync(
        Func<TSuccess, ValueTask<Result<TSuccess, TFailure>>> nextFactoryAsync)
        =>
        InnerForwardValueAsync(
            nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync)));
}
