namespace System;

// TODO: Add the tests and open the type
internal readonly partial struct Nonsuccess<TFailure> : IEquatable<Nonsuccess<TFailure>>
    where TFailure : struct
{
    private readonly TFailure failure;
}
