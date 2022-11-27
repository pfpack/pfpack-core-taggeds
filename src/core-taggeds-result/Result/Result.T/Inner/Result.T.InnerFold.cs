using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InnerFold<TResult>(
        Func<TSuccess, TResult> mapSuccess,
        Func<TFailure, TResult> mapFailure)
        =>
        isSuccess
            ? mapSuccess.Invoke(success)
            : mapFailure.Invoke(failure);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TResult> InnerFoldAsync<TResult>(
        Func<TSuccess, Task<TResult>> mapSuccessAsync,
        Func<TFailure, Task<TResult>> mapFailureAsync)
        =>
        isSuccess
            ? mapSuccessAsync.Invoke(success)
            : mapFailureAsync.Invoke(failure);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TResult> InnerFoldValueAsync<TResult>(
        Func<TSuccess, ValueTask<TResult>> mapSuccessAsync,
        Func<TFailure, ValueTask<TResult>> mapFailureAsync)
        =>
        isSuccess
            ? mapSuccessAsync.Invoke(success)
            : mapFailureAsync.Invoke(failure);
}
