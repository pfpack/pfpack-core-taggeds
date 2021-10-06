#nullable enable

namespace System;

partial struct Failure<TFailureCode>
{
    public static bool Equals(Failure<TFailureCode> left, Failure<TFailureCode> right)
        =>
        left.Equals(right);

    public static bool operator ==(Failure<TFailureCode> left, Failure<TFailureCode> right)
        =>
        left.Equals(right);

    public static bool operator !=(Failure<TFailureCode> left, Failure<TFailureCode> right)
        =>
        left.Equals(right) is false;

    public override bool Equals(object? obj)
        =>
        obj is Failure<TFailureCode> other &&
        Equals(other);
}
