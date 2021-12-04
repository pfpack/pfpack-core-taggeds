namespace System;

partial struct Result<TSuccess, TFailure>
{
    public static Result<TSuccess, TFailure> Success(TSuccess success)
        =>
        new(success);

    public static Result<TSuccess, TFailure> Failure(TFailure failure)
        =>
        new(failure);
}
