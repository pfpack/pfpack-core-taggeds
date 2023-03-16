namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result<TNextSuccess, TNextFailure> Forward<TNextSuccess, TNextFailure>(
        Func<TSuccess, Result<TNextSuccess, TNextFailure>> nextFactory,
        Func<TFailure, TNextFailure> mapFailure)
        where TNextFailure : struct
        =>
        InnerForward(
            nextFactory ?? throw new ArgumentNullException(nameof(nextFactory)),
            mapFailure ?? throw new ArgumentNullException(nameof(mapFailure)));

    public Result<TNextSuccess, TFailure> Forward<TNextSuccess>(
        Func<TSuccess, Result<TNextSuccess, TFailure>> nextFactory)
        =>
        InnerForward(
            nextFactory ?? throw new ArgumentNullException(nameof(nextFactory)));

    public Result<TSuccess, TFailure> Forward(
        Func<TSuccess, Result<TSuccess, TFailure>> nextFactory)
        =>
        InnerForward(
            nextFactory ?? throw new ArgumentNullException(nameof(nextFactory)));
}
