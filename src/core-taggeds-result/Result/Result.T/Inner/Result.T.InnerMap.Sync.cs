using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TResultSuccess, TResultFailure> InnerMap<TResultSuccess, TResultFailure>(
        Func<TSuccess, TResultSuccess> mapSuccess,
        Func<TFailure, TResultFailure> mapFailure)
        where TResultFailure : struct
        =>
        isSuccess
            ? mapSuccess.Invoke(success)
            : mapFailure.Invoke(failure);
}
