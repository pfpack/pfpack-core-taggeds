using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Task<TResult> FoldAsync<TResult>(
        Func<TSuccess, Task<TResult>> mapSuccessAsync,
        Func<TFailure, Task<TResult>> mapFailureAsync)
        =>
        InnerFoldAsync(
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));
}
