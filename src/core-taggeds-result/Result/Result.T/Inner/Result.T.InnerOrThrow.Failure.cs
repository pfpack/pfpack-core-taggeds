using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TFailure InnerFailureOrThrow(Func<Exception> exceptionFactory)
        =>
        isSuccess is not true
            ? failure
            : throw exceptionFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TFailure InnerFailureOrThrow(Func<TSuccess, Exception> exceptionFactory)
        =>
        isSuccess is not true
            ? failure
            : throw exceptionFactory.Invoke(success);
}
