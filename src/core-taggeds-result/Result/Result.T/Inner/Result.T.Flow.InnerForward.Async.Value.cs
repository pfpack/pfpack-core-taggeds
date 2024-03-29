﻿using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TNextSuccess, TNextFailure>> InnerForwardValueAsync<TNextSuccess, TNextFailure>(
        Func<TSuccess, ValueTask<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
        Func<TFailure, ValueTask<TNextFailure>> mapFailureAsync)
        where TNextFailure : struct
        =>
        isSuccess
        ? await nextFactoryAsync.Invoke(success).ConfigureAwait(false)
        : new(await mapFailureAsync.Invoke(failure).ConfigureAwait(false));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TNextSuccess, TNextFailure>> InnerForwardValueAsync<TNextSuccess, TNextFailure>(
        Func<TSuccess, ValueTask<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
        Func<TFailure, TNextFailure> mapFailure)
        where TNextFailure : struct
        =>
        isSuccess
        ? await nextFactoryAsync.Invoke(success).ConfigureAwait(false)
        : new(mapFailure.Invoke(failure));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TNextSuccess, TFailure>> InnerForwardValueAsync<TNextSuccess>(
        Func<TSuccess, ValueTask<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
        =>
        isSuccess
        ? await nextFactoryAsync.Invoke(success).ConfigureAwait(false)
        : new(failure);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TSuccess, TFailure>> InnerForwardValueAsync(
        Func<TSuccess, ValueTask<Result<TSuccess, TFailure>>> nextFactoryAsync)
        =>
        isSuccess
        ? await nextFactoryAsync.Invoke(success).ConfigureAwait(false)
        : this;
}
