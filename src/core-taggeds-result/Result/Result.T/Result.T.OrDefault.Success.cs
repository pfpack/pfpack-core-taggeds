namespace System;

partial struct Result<TSuccess, TFailure>
{
    public TSuccess? SuccessOrDefault()
        =>
        InnerSuccessOrDefault();
}
