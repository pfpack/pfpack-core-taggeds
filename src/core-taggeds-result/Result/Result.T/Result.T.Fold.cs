using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public TResult Fold<TResult>(
        Func<TSuccess, TResult> mapSuccess,
        Func<TFailure, TResult> mapFailure)
        =>
        InnerFold(
            mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess)),
            mapFailure ?? throw new ArgumentNullException(nameof(mapFailure)));

    public Task<TResult> FoldAsync<TResult>(
        Func<TSuccess, Task<TResult>> mapSuccessAsync,
        Func<TFailure, Task<TResult>> mapFailureAsync)
        =>
        InnerFoldAsync(
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));

    public ValueTask<TResult> FoldValueAsync<TResult>(
        Func<TSuccess, ValueTask<TResult>> mapSuccessAsync,
        Func<TFailure, ValueTask<TResult>> mapFailureAsync)
        =>
        InnerFoldValueAsync(
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));
}
