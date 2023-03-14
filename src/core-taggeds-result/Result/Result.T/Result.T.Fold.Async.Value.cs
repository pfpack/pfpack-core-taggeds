using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public ValueTask<TResult> FoldValueAsync<TResult>(
        Func<TSuccess, ValueTask<TResult>> mapSuccessAsync,
        Func<TFailure, ValueTask<TResult>> mapFailureAsync)
        =>
        InnerFoldValueAsync(
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));
}
