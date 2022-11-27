using System;

namespace PrimeFuncPack.Core;

public readonly partial struct FailureBuilder<TFailure> : IEquatable<FailureBuilder<TFailure>>
    where TFailure : struct
{
    private readonly TFailure failure;

    internal FailureBuilder(TFailure failure)
        =>
        this.failure = failure;

    internal TFailure InternalValue
        =>
        failure;

    public Result<TSuccess, TFailure> With<TSuccess>()
        =>
        new(failure);
}
