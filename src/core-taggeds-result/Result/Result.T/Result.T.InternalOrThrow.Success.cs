using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TSuccess InternalSuccessOrThrow(Func<Exception> exceptionFactory)
        =>
        isSuccess
            ? success
            : throw exceptionFactory.Invoke();
}
