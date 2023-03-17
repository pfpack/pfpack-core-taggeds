using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TSuccess, TCauseFailure>> InnerFilterAsync<TCauseFailure>(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, Task<TCauseFailure>> mapFailureAsync)
        where TCauseFailure : struct
    {
        if (isSuccess)
        {
            return await predicateAsync.Invoke(success).ConfigureAwait(false)
                ? new(success)
                : new(await causeFactoryAsync.Invoke(success).ConfigureAwait(false));
        }

        return new(await mapFailureAsync.Invoke(failure).ConfigureAwait(false));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TSuccess, TCauseFailure>> InnerFilterAsync<TCauseFailure>(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, TCauseFailure> mapFailure)
        where TCauseFailure : struct
    {
        if (isSuccess)
        {
            return await predicateAsync.Invoke(success).ConfigureAwait(false)
                ? new(success)
                : new(await causeFactoryAsync.Invoke(success).ConfigureAwait(false));
        }

        return new(mapFailure.Invoke(failure));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TSuccess, TFailure>> InnerFilterAsync(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TFailure>> causeFactoryAsync)
    {
        if (isSuccess)
        {
            return await predicateAsync.Invoke(success).ConfigureAwait(false)
                ? this
                : new(await causeFactoryAsync.Invoke(success).ConfigureAwait(false));
        }

        return this;
    }
}
