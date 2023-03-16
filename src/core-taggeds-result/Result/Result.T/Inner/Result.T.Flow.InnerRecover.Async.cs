using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TOtherSuccess, TOtherFailure>> InnerRecoverAsync<TOtherSuccess, TOtherFailure>(
        Func<TFailure, Task<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
        Func<TSuccess, Task<TOtherSuccess>> mapSuccessAsync)
        where TOtherFailure : struct
        =>
        isSuccess
        ? new(await mapSuccessAsync.Invoke(success).ConfigureAwait(false))
        : await otherFactoryAsync.Invoke(failure).ConfigureAwait(false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TSuccess, TOtherFailure>> InnerRecoverAsync<TOtherFailure>(
        Func<TFailure, Task<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
        where TOtherFailure : struct
        =>
        isSuccess
        ? new(success)
        : await otherFactoryAsync.Invoke(failure).ConfigureAwait(false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TSuccess, TFailure>> InnerRecoverAsync(
        Func<TFailure, Task<Result<TSuccess, TFailure>>> otherFactoryAsync)
        =>
        isSuccess
        ? this
        : await otherFactoryAsync.Invoke(failure).ConfigureAwait(false);
}
