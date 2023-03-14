using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TResult> InnerFoldAsync<TResult>(
        Func<TSuccess, Task<TResult>> mapSuccessAsync,
        Func<TFailure, Task<TResult>> mapFailureAsync)
        =>
        isSuccess
            ? mapSuccessAsync.Invoke(success)
            : mapFailureAsync.Invoke(failure);
}
