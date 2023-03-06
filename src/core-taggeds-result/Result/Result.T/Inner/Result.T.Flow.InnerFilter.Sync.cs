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
        if (isSuccess is not true)
        {
            return new(mapFailure.Invoke(failure));
        }

        if (predicate.Invoke(success))
        {
            return new(success);
        }

        return new(causeFactory.Invoke(success));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TSuccess, TFailure> InnerFilter(
        Func<TSuccess, bool> predicate,
        Func<TSuccess, TFailure> causeFactory)
    {
        if (isSuccess is not true)
        {
            return this;
        }

        if (predicate.Invoke(success))
        {
            return this;
        }

        return new(causeFactory.Invoke(success));
    }
}
