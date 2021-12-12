namespace System;

// TODO: Add the tests and open the type
internal readonly partial struct Present<T> : IEquatable<Present<T>>
{
    private readonly T value;
}
