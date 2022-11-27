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
        return InnerFold(FilterSuccess, failure => mapFailure.Invoke(failure));

        Result<TSuccess, TCauseFailure> FilterSuccess(TSuccess success)
            =>
            predicate.Invoke(success)
                ? success
                : causeFactory.Invoke(success);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TSuccess, TFailure> InnerFilter(
        Func<TSuccess, bool> predicate,
        Func<TSuccess, TFailure> causeFactory)
    {
        var @this = this;

        return InnerFold(FilterSuccess, _ => @this);

        Result<TSuccess, TFailure> FilterSuccess(TSuccess success)
            =>
            predicate.Invoke(success)
                ? @this
                : causeFactory.Invoke(success);
    }
}
