namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result<TSuccess, TResultFailure> MapFailure<TResultFailure>(
        Func<TFailure, TResultFailure> mapFailure)
        where TResultFailure : struct
        =>
        InnerMapFailure(
            mapFailure ?? throw new ArgumentNullException(nameof(mapFailure)));
}
