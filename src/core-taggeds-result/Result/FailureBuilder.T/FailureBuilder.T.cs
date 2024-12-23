﻿namespace System;

public readonly partial struct FailureBuilder<TFailure> : IEquatable<FailureBuilder<TFailure>>
    where TFailure : struct
{
    private readonly TFailure failure;

    internal FailureBuilder(TFailure failure)
        =>
        this.failure = failure;
}
