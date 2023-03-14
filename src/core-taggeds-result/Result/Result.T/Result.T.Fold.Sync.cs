namespace System;

partial struct Result<TSuccess, TFailure>
{
    public TResult Fold<TResult>(
        Func<TSuccess, TResult> mapSuccess,
        Func<TFailure, TResult> mapFailure)
        =>
        InnerFold(
            mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess)),
            mapFailure ?? throw new ArgumentNullException(nameof(mapFailure)));
}
