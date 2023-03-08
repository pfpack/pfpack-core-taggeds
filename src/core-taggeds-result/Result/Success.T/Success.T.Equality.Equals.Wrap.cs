using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct Success<TSuccess>
{
    public static bool Equals(Success<TSuccess> left, Success<TSuccess> right)
        =>
        left.Equals(right);

    public static bool operator ==(Success<TSuccess> left, Success<TSuccess> right)
        =>
        left.Equals(right);

    public static bool operator !=(Success<TSuccess> left, Success<TSuccess> right)
        =>
        left.Equals(right) is not true;

    public override bool Equals([NotNullWhen(true)] object? obj)
        =>
        obj is Success<TSuccess> other &&
        Equals(other);
}
