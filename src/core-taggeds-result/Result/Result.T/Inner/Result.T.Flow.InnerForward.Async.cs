using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TNextSuccess, TNextFailure>> InnerForwardAsync<TNextSuccess, TNextFailure>(
        Func<TSuccess, Task<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
        Func<TFailure, Task<TNextFailure>> mapFailureAsync)
        where TNextFailure : struct
        =>
        isSuccess
        ? await nextFactoryAsync.Invoke(success).ConfigureAwait(false)
        : new(await mapFailureAsync.Invoke(failure).ConfigureAwait(false));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TNextSuccess, TFailure>> InnerForwardAsync<TNextSuccess>(
        Func<TSuccess, Task<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
        =>
        isSuccess
        ? await nextFactoryAsync.Invoke(success).ConfigureAwait(false)
        : new(failure);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TSuccess, TFailure>> InnerForwardAsync(
        Func<TSuccess, Task<Result<TSuccess, TFailure>>> nextFactoryAsync)
        =>
        isSuccess
        ? await nextFactoryAsync.Invoke(success).ConfigureAwait(false)
        : this;
}
