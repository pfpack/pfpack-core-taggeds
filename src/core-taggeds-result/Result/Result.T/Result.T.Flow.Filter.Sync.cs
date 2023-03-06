namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result<TSuccess, TCauseFailure> Filter<TCauseFailure>(
        Func<TSuccess, bool> predicate,
        Func<TSuccess, TCauseFailure> causeFactory,
        Func<TFailure, TCauseFailure> mapFailure)
        where TCauseFailure : struct
        =>
        InnerFilter(
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            causeFactory ?? throw new ArgumentNullException(nameof(causeFactory)),
            mapFailure ?? throw new ArgumentNullException(nameof(mapFailure)));

    public Result<TSuccess, TFailure> Filter(
        Func<TSuccess, bool> predicate,
        Func<TSuccess, TFailure> causeFactory)
        =>
        InnerFilter(
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            causeFactory ?? throw new ArgumentNullException(nameof(causeFactory)));
}
