namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result<TResultSuccess, TFailure> MapSuccess<TResultSuccess>(
        Func<TSuccess, TResultSuccess> mapSuccess)
        =>
        InnerMapSuccess(
            mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess)));
}
