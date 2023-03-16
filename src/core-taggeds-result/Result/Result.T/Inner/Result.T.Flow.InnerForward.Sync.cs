using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TNextSuccess, TNextFailure> InnerForward<TNextSuccess, TNextFailure>(
        Func<TSuccess, Result<TNextSuccess, TNextFailure>> nextFactory,
        Func<TFailure, TNextFailure> mapFailure)
        where TNextFailure : struct
        =>
        isSuccess
        ? nextFactory.Invoke(success)
        : new(mapFailure.Invoke(failure));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TNextSuccess, TFailure> InnerForward<TNextSuccess>(
        Func<TSuccess, Result<TNextSuccess, TFailure>> nextFactory)
        =>
        isSuccess
        ? nextFactory.Invoke(success)
        : new(failure);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TSuccess, TFailure> InnerForward(
        Func<TSuccess, Result<TSuccess, TFailure>> nextFactory)
        =>
        isSuccess
        ? nextFactory.Invoke(success)
        : this;
}
