using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Task<Result<TNextSuccess, TNextFailure>> ForwardAsync<TNextSuccess, TNextFailure>(
        Func<TSuccess, Task<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
        Func<TFailure, Task<TNextFailure>> mapFailureAsync)
        where TNextFailure : struct
        =>
        InnerForwardAsync(
            nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));

    public Task<Result<TNextSuccess, TFailure>> ForwardAsync<TNextSuccess>(
        Func<TSuccess, Task<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
        =>
        InnerForwardAsync(
            nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync)));

    public Task<Result<TSuccess, TFailure>> ForwardAsync(
        Func<TSuccess, Task<Result<TSuccess, TFailure>>> nextFactoryAsync)
        =>
        InnerForwardAsync(
            nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync)));
}
