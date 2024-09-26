using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct SuccessBuilder<TSuccess>
{
    public static bool Equals(SuccessBuilder<TSuccess> left, SuccessBuilder<TSuccess> right)
        =>
        left.Equals(right);

    public static bool operator ==(SuccessBuilder<TSuccess> left, SuccessBuilder<TSuccess> right)
        =>
        left.Equals(right);

    public static bool operator !=(SuccessBuilder<TSuccess> left, SuccessBuilder<TSuccess> right)
        =>
        left.Equals(right) is not true;

    public override bool Equals([NotNullWhen(true)] object? obj)
        =>
        obj is SuccessBuilder<TSuccess> other &&
        Equals(other);
}
