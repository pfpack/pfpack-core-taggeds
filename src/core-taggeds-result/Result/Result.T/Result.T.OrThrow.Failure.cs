namespace System;

partial struct Result<TSuccess, TFailure>
{
    public TFailure FailureOrThrow()
        =>
        InternalFailureOrThrow(CreateNotFailureException);

    public TFailure FailureOrThrow(Func<Exception> exceptionFactory)
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return InternalFailureOrThrow(exceptionFactory);
    }
}
