using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TOtherSuccess, TOtherFailure> InnerRecover<TOtherSuccess, TOtherFailure>(
        Func<TFailure, Result<TOtherSuccess, TOtherFailure>> otherFactory,
        Func<TSuccess, TOtherSuccess> mapSuccess)
        where TOtherFailure : struct
        =>
        isSuccess
        ? new(mapSuccess.Invoke(success))
        : otherFactory.Invoke(failure);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TSuccess, TOtherFailure> InnerRecover<TOtherFailure>(
        Func<TFailure, Result<TSuccess, TOtherFailure>> otherFactory)
        where TOtherFailure : struct
        =>
        isSuccess
        ? new(success)
        : otherFactory.Invoke(failure);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TSuccess, TFailure> InnerRecover(
        Func<TFailure, Result<TSuccess, TFailure>> otherFactory)
        =>
        isSuccess
        ? this
        : otherFactory.Invoke(failure);
}
