using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TSuccess InnerSuccessOrElse(TSuccess other)
        =>
        isSuccess ? success : other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TSuccess InnerSuccessOrElse(Func<TSuccess> otherFactory)
        =>
        isSuccess ? success : otherFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TSuccess InnerSuccessOrElse(Func<TFailure, TSuccess> otherFactory)
        =>
        isSuccess ? success : otherFactory.Invoke(failure);
}
