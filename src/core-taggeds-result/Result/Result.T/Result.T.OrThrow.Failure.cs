namespace System;

partial struct Result<TSuccess, TFailure>
{
    public TFailure FailureOrThrow()
        =>
        InnerFailureOrThrow(CreateNotFailureException);

    public TFailure FailureOrThrow(Func<Exception> exceptionFactory)
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return InnerFailureOrThrow(exceptionFactory);
    }
}
