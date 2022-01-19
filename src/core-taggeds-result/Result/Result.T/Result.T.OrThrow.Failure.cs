namespace System;

partial struct Result<TSuccess, TFailure>
{
    public TFailure FailureOrThrow()
        =>
        InnerFailureOrThrow(InnerCreateExpectedFailureException);

    public TFailure FailureOrThrow(Func<Exception> exceptionFactory)
        =>
        InnerFailureOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
}
