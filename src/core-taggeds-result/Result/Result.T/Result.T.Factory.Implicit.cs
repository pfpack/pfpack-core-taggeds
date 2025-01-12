namespace System;

partial struct Result<TSuccess, TFailure>
{
    public static implicit operator Result<TSuccess, TFailure>(TSuccess success)
        =>
        new(success);

    public static implicit operator Result<TSuccess, TFailure>(TFailure failure)
        =>
        new(failure);

    // TODO: Add the tests and open the operator
    //public static implicit operator Result<TSuccess, TFailure>(Success<TSuccess> success)
    //    =>
    //    success.ToResult<TFailure>();

    // TODO: Add the tests and open the operator
    //public static implicit operator Result<TSuccess, TFailure>(Nonsuccess<TFailure> nonsuccess)
    //    =>
    //    nonsuccess.ToResult<TSuccess>();

    public static implicit operator Result<TSuccess, TFailure>(SuccessBuilder<TSuccess> success)
        =>
        success.With<TFailure>();

    public static implicit operator Result<TSuccess, TFailure>(FailureBuilder<TFailure> failure)
        =>
        failure.With<TSuccess>();
}
