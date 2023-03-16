using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TOtherSuccess, TOtherFailure>> InnerRecoverValueAsync<TOtherSuccess, TOtherFailure>(
        Func<TFailure, ValueTask<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
        Func<TSuccess, ValueTask<TOtherSuccess>> mapSuccessAsync)
        where TOtherFailure : struct
        =>
        isSuccess
        ? new(await mapSuccessAsync.Invoke(success).ConfigureAwait(false))
        : await otherFactoryAsync.Invoke(failure).ConfigureAwait(false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TSuccess, TOtherFailure>> InnerRecoverValueAsync<TOtherFailure>(
        Func<TFailure, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
        where TOtherFailure : struct
        =>
        isSuccess
        ? new(success)
        : await otherFactoryAsync.Invoke(failure).ConfigureAwait(false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TSuccess, TFailure>> InnerRecoverValueAsync(
        Func<TFailure, ValueTask<Result<TSuccess, TFailure>>> otherFactoryAsync)
        =>
        isSuccess
        ? this
        : await otherFactoryAsync.Invoke(failure).ConfigureAwait(false);
}
