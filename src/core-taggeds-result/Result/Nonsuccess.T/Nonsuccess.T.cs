namespace System;

// TODO: Add the tests!
public readonly partial struct Nonsuccess<TFailure> : IEquatable<Nonsuccess<TFailure>>
    where TFailure : struct
{
    private readonly TFailure failure;

    internal TFailure InternalFailure
        =>
        failure;
}
