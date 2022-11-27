using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<Result<TSuccess, TCauseFailure>> InnerFilterValueAsync<TCauseFailure>(
        Func<TSuccess, ValueTask<bool>> predicateAsync,
        Func<TSuccess, ValueTask<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, ValueTask<TCauseFailure>> mapFailureAsync)
        where TCauseFailure : struct
    {
        return InnerFold(FilterSuccessAsync, MapFailureAsync);

        async ValueTask<Result<TSuccess, TCauseFailure>> FilterSuccessAsync(TSuccess success)
            =>
            await predicateAsync.Invoke(success).ConfigureAwait(false)
                ? success
                : await causeFactoryAsync.Invoke(success).ConfigureAwait(false);

        async ValueTask<Result<TSuccess, TCauseFailure>> MapFailureAsync(TFailure failure)
            =>
            await mapFailureAsync.Invoke(failure).ConfigureAwait(false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<Result<TSuccess, TFailure>> InnerFilterValueAsync(
        Func<TSuccess, ValueTask<bool>> predicateAsync,
        Func<TSuccess, ValueTask<TFailure>> causeFactoryAsync)
    {
        var @this = this;

        return InnerFold(FilterSuccessAsync, _ => ValueTask.FromResult(@this));

        async ValueTask<Result<TSuccess, TFailure>> FilterSuccessAsync(TSuccess success)
            =>
            await predicateAsync.Invoke(success).ConfigureAwait(false)
                ? @this
                : await causeFactoryAsync.Invoke(success).ConfigureAwait(false);
    }
}
