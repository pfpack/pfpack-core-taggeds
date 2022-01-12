using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Core;

partial struct FailureBuilder<TFailure>
{
    public static bool Equals(FailureBuilder<TFailure> left, FailureBuilder<TFailure> right)
        =>
        left.Equals(right);

    public static bool operator ==(FailureBuilder<TFailure> left, FailureBuilder<TFailure> right)
        =>
        left.Equals(right);

    public static bool operator !=(FailureBuilder<TFailure> left, FailureBuilder<TFailure> right)
        =>
        left.Equals(right) is false;

    public override bool Equals([NotNullWhen(true)] object? obj)
        =>
        obj is FailureBuilder<TFailure> other &&
        Equals(other);
}
