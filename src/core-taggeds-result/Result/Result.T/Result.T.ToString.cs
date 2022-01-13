namespace System;

partial struct Result<TSuccess, TFailure>
{
    public override string ToString()
        =>
        InnerToString();
}
