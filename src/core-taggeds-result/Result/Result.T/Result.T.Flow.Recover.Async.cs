using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Task<Result<TOtherSuccess, TOtherFailure>> RecoverAsync<TOtherSuccess, TOtherFailure>(
        Func<TFailure, Task<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
        Func<TSuccess, Task<TOtherSuccess>> mapSuccessAsync)
        where TOtherFailure : struct
        =>
        InnerRecoverAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)),
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)));

    public Task<Result<TOtherSuccess, TOtherFailure>> RecoverAsync<TOtherSuccess, TOtherFailure>(
        Func<TFailure, Task<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
        Func<TSuccess, TOtherSuccess> mapSuccess)
        where TOtherFailure : struct
        =>
        InnerRecoverAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)),
            mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess)));

    public Task<Result<TSuccess, TOtherFailure>> RecoverAsync<TOtherFailure>(
        Func<TFailure, Task<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
        where TOtherFailure : struct
        =>
        InnerRecoverAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    public Task<Result<TSuccess, TFailure>> RecoverAsync(
        Func<TFailure, Task<Result<TSuccess, TFailure>>> otherFactoryAsync)
        =>
        InnerRecoverAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}
