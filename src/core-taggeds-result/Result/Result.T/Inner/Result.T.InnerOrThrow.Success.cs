using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TSuccess InnerSuccessOrThrow(Func<Exception> exceptionFactory)
        =>
        isSuccess
            ? success
            : throw exceptionFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TSuccess InnerSuccessOrThrow(Func<TFailure, Exception> exceptionFactory)
        =>
        isSuccess
            ? success
            : throw exceptionFactory.Invoke(failure);
}
