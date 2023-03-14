using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TResult> InnerFoldValueAsync<TResult>(
        Func<TSuccess, ValueTask<TResult>> mapSuccessAsync,
        Func<TFailure, ValueTask<TResult>> mapFailureAsync)
        =>
        isSuccess
            ? mapSuccessAsync.Invoke(success)
            : mapFailureAsync.Invoke(failure);
}
