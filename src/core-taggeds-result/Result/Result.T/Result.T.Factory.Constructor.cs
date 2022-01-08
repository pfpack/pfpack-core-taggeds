namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result(TSuccess success)
        =>
        (this.success, isSuccess, failure) = (success, true, default);

    public Result(TFailure failure)
        =>
        (this.failure, isSuccess, success) = (failure, false, default!);
}
