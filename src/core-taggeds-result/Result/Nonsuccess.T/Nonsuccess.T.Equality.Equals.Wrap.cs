using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct Nonsuccess<TFailure>
{
    public static bool Equals(Nonsuccess<TFailure> left, Nonsuccess<TFailure> right)
        =>
        left.Equals(right);

    public static bool operator ==(Nonsuccess<TFailure> left, Nonsuccess<TFailure> right)
        =>
        left.Equals(right);

    public static bool operator !=(Nonsuccess<TFailure> left, Nonsuccess<TFailure> right)
        =>
        left.Equals(right) is not true;

    public override bool Equals([NotNullWhen(true)] object? obj)
        =>
        obj is Nonsuccess<TFailure> other &&
        Equals(other);
}
