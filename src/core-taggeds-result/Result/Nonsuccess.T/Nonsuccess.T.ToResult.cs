namespace System;

partial struct Nonsuccess<TFailure>
{
    public Result<TSuccess, TFailure> ToResult<TSuccess>()
        =>
        new(failure);
}
