using System;

// TODO: Move to System namespace in Result v3.0
namespace PrimeFuncPack.Core;

public readonly partial struct FailureBuilder<TFailure> : IEquatable<FailureBuilder<TFailure>>
    where TFailure : struct
{
    private readonly TFailure failure;

    internal FailureBuilder(TFailure failure)
        =>
        this.failure = failure;
}
