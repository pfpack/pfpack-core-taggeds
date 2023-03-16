namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result<TOtherSuccess, TOtherFailure> Recover<TOtherSuccess, TOtherFailure>(
        Func<TFailure, Result<TOtherSuccess, TOtherFailure>> otherFactory,
        Func<TSuccess, TOtherSuccess> mapSuccess)
        where TOtherFailure : struct
        =>
        InnerRecover(
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)),
            mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess)));

    public Result<TSuccess, TOtherFailure> Recover<TOtherFailure>(
        Func<TFailure, Result<TSuccess, TOtherFailure>> otherFactory)
        where TOtherFailure : struct
        =>
        InnerRecover(
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    public Result<TSuccess, TFailure> Recover(
        Func<TFailure, Result<TSuccess, TFailure>> otherFactory)
        =>
        InnerRecover(
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));
}
