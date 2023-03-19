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
        isSuccess is not true
        ? await otherFactoryAsync.Invoke(failure).ConfigureAwait(false)
        : new(await mapSuccessAsync.Invoke(success).ConfigureAwait(false));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TOtherSuccess, TOtherFailure>> InnerRecoverValueAsync<TOtherSuccess, TOtherFailure>(
        Func<TFailure, ValueTask<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
        Func<TSuccess, TOtherSuccess> mapSuccess)
        where TOtherFailure : struct
        =>
        isSuccess is not true
        ? await otherFactoryAsync.Invoke(failure).ConfigureAwait(false)
        : new(mapSuccess.Invoke(success));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TSuccess, TOtherFailure>> InnerRecoverValueAsync<TOtherFailure>(
        Func<TFailure, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
        where TOtherFailure : struct
        =>
        isSuccess is not true
        ? await otherFactoryAsync.Invoke(failure).ConfigureAwait(false)
        : new(success);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TSuccess, TFailure>> InnerRecoverValueAsync(
        Func<TFailure, ValueTask<Result<TSuccess, TFailure>>> otherFactoryAsync)
        =>
        isSuccess is not true
        ? await otherFactoryAsync.Invoke(failure).ConfigureAwait(false)
        : this;
}
