using System.Diagnostics.CodeAnalysis;

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
        left.Equals(right) is not true;

    public override bool Equals([NotNullWhen(true)] object? obj)
        =>
        obj is Failure<TFailureCode> other &&
        Equals(other);
}
