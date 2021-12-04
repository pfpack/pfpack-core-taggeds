namespace System;

public readonly partial struct Result<TSuccess, TFailure> : IEquatable<Result<TSuccess, TFailure>>
    where TFailure : struct
{
    private readonly bool isSuccess;

    private readonly TSuccess success;

    private readonly TFailure failure;

    public bool IsSuccess => isSuccess;

    public bool IsFailure => isSuccess is false;
}
