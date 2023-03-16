using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TSuccess, TCauseFailure>> InnerFilterValueAsync<TCauseFailure>(
        Func<TSuccess, ValueTask<bool>> predicateAsync,
        Func<TSuccess, ValueTask<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, ValueTask<TCauseFailure>> mapFailureAsync)
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
    private async ValueTask<Result<TSuccess, TCauseFailure>> InnerFilterValueAsync<TCauseFailure>(
        Func<TSuccess, ValueTask<bool>> predicateAsync,
        Func<TSuccess, ValueTask<TCauseFailure>> causeFactoryAsync,
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
    private async ValueTask<Result<TSuccess, TFailure>> InnerFilterValueAsync(
        Func<TSuccess, ValueTask<bool>> predicateAsync,
        Func<TSuccess, ValueTask<TFailure>> causeFactoryAsync)
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
