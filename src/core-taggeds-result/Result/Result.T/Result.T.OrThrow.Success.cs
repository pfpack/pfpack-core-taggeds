namespace System;

partial struct Result<TSuccess, TFailure>
{
    public TSuccess SuccessOrThrow()
        =>
        InnerSuccessOrThrow(InnerCreateExpectedSuccessException);

    public TSuccess SuccessOrThrow(Func<Exception> exceptionFactory)
        =>
        InnerSuccessOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
}
