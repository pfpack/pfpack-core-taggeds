namespace System;

partial struct Success<TSuccess>
{
    public Result<TSuccess, TFailure> ToResult<TFailure>()
        where TFailure : struct
        =>
        new(success);
}
