namespace System;

partial struct Result<TSuccess, TFailure>
{
    public TSuccess SuccessOrThrow()
        =>
        InnerSuccessOrThrow(InnerCreateExpectedSuccessException);

    public TSuccess SuccessOrThrow(Func<Exception> exceptionFactory)
        =>
        InnerSuccessOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));

    public TSuccess SuccessOrThrow(Func<TFailure, Exception> exceptionFactory)
        =>
        InnerSuccessOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
}
