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
        if (isSuccess is not true)
        {
            return new(await mapFailureAsync.Invoke(failure).ConfigureAwait(false));
        }

        if (await predicateAsync.Invoke(success).ConfigureAwait(false))
        {
            return new(success);
        }

        return new(await causeFactoryAsync.Invoke(success).ConfigureAwait(false));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TSuccess, TCauseFailure>> InnerFilterAsync<TCauseFailure>(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, TCauseFailure> mapFailure)
        where TCauseFailure : struct
    {
        if (isSuccess is not true)
        {
            return mapFailure.Invoke(failure);
        }

        if (await predicateAsync.Invoke(success).ConfigureAwait(false))
        {
            return new(success);
        }

        return new(await causeFactoryAsync.Invoke(success).ConfigureAwait(false));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TSuccess, TFailure>> InnerFilterAsync(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TFailure>> causeFactoryAsync)
    {
        if (isSuccess is not true)
        {
            return this;
        }

        if (await predicateAsync.Invoke(success).ConfigureAwait(false))
        {
            return this;
        }

        return new(await causeFactoryAsync.Invoke(success).ConfigureAwait(false));
    }
}
