namespace System;

partial struct Result<TSuccess, TFailure>
{
    // TODO: Add the tests and open the methods

    internal TSuccess SuccessOrElse(TSuccess other)
        =>
        InnerSuccessOrElse(other);

    internal TSuccess SuccessOrElse(Func<TSuccess> otherFactory)
        =>
        InnerSuccessOrElse(otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    internal TSuccess SuccessOrElse(Func<TFailure, TSuccess> otherFactory)
        =>
        InnerSuccessOrElse(otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));
}
