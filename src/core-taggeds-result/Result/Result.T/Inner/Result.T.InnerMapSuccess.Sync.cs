using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TResultSuccess, TFailure> InnerMapSuccess<TResultSuccess>(
        Func<TSuccess, TResultSuccess> mapSuccess)
        =>
        isSuccess
            ? new(mapSuccess.Invoke(success))
            : new(failure);
}
