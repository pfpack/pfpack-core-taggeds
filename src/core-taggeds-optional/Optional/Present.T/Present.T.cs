namespace System;

internal readonly partial struct Present<T> : IEquatable<Present<T>>
{
    private readonly T value;
}
