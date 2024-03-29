﻿using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InnerFold<TResult>(
        Func<TSuccess, TResult> mapSuccess,
        Func<TFailure, TResult> mapFailure)
        =>
        isSuccess
            ? mapSuccess.Invoke(success)
            : mapFailure.Invoke(failure);
}
