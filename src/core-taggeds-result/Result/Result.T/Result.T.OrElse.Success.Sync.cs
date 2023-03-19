namespace System;

partial struct Result<TSuccess, TFailure>
{
    // TODO: Add the tests

    public TSuccess SuccessOrElse(TSuccess other)
        =>
        InnerSuccessOrElse(other);

    public TSuccess SuccessOrElse(Func<TSuccess> otherFactory)
        =>
        InnerSuccessOrElse(otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    public TSuccess SuccessOrElse(Func<TFailure, TSuccess> otherFactory)
        =>
        InnerSuccessOrElse(otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));
}
