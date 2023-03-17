namespace System;

partial struct Result<TSuccess, TFailure>
{
    // TODO: Add the tests

    public TSuccess? SuccessOrDefault()
        =>
        InnerSuccessOrDefault();
}
