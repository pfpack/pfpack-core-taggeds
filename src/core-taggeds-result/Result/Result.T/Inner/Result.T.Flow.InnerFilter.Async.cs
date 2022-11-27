using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<Result<TSuccess, TCauseFailure>> InnerFilterAsync<TCauseFailure>(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, Task<TCauseFailure>> mapFailureAsync)
        where TCauseFailure : struct
    {
        return InnerFold(FilterSuccessAsync, MapFailureAsync);

        async Task<Result<TSuccess, TCauseFailure>> FilterSuccessAsync(TSuccess success)
            =>
            await predicateAsync.Invoke(success).ConfigureAwait(false)
                ? success
                : await causeFactoryAsync.Invoke(success).ConfigureAwait(false);

        async Task<Result<TSuccess, TCauseFailure>> MapFailureAsync(TFailure failure)
            =>
            await mapFailureAsync.Invoke(failure).ConfigureAwait(false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<Result<TSuccess, TFailure>> InnerFilterAsync(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TFailure>> causeFactoryAsync)
    {
        var @this = this;

        return InnerFold(FilterSuccessAsync, _ => Task.FromResult(@this));

        async Task<Result<TSuccess, TFailure>> FilterSuccessAsync(TSuccess success)
            =>
            await predicateAsync.Invoke(success).ConfigureAwait(false)
                ? @this
                : await causeFactoryAsync.Invoke(success).ConfigureAwait(false);
    }
}
