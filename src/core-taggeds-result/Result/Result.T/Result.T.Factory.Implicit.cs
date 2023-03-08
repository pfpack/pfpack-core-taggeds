using PrimeFuncPack.Core;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public static implicit operator Result<TSuccess, TFailure>(TSuccess success)
        =>
        new(success);

    public static implicit operator Result<TSuccess, TFailure>(TFailure failure)
        =>
        new(failure);

    // TODO: Add the tests!
    public static implicit operator Result<TSuccess, TFailure>(Success<TSuccess> success)
        =>
        new(success.InternalSuccess);

    // TODO: Add the tests!
    public static implicit operator Result<TSuccess, TFailure>(Nonsuccess<TFailure> nonsuccess)
        =>
        new(nonsuccess.InternalFailure);

    public static implicit operator Result<TSuccess, TFailure>(SuccessBuilder<TSuccess> success)
        =>
        new(success.InternalSuccess);

    public static implicit operator Result<TSuccess, TFailure>(FailureBuilder<TFailure> failure)
        =>
        new(failure.InternalFailure);
}
