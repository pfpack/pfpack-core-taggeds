using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TSuccess, TCauseFailure> InnerFilter<TCauseFailure>(
        Func<TSuccess, bool> predicate,
        Func<TSuccess, TCauseFailure> causeFactory,
        Func<TFailure, TCauseFailure> mapFailure)
        where TCauseFailure : struct
    {
        if (isSuccess)
        {
            return predicate.Invoke(success)
                ? new(success)
                : new(causeFactory.Invoke(success));
        }

        return new(mapFailure.Invoke(failure));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TSuccess, TFailure> InnerFilter(
        Func<TSuccess, bool> predicate,
        Func<TSuccess, TFailure> causeFactory)
    {
        if (isSuccess)
        {
            return predicate.Invoke(success)
                ? this
                : new(causeFactory.Invoke(success));
        }

        return this;
    }
}
