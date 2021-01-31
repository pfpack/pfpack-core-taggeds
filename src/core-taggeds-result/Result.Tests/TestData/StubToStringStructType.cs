#nullable enable

using System;

namespace PrimeFuncPack.Core.Tests
{
    internal readonly struct StubToStringStructType
    {
        private readonly string? toStringValue;

        public StubToStringStructType(string? toStringValue)
            =>
            this.toStringValue = toStringValue;

        public override string? ToString()
            =>
            toStringValue;

        public bool Equals(StubToStringStructType other)
            =>
            StringEquality.Equals(toStringValue, other.toStringValue);

        public static bool operator ==(StubToStringStructType left, StubToStringStructType right)
            =>
            left.Equals(right);

        public static bool operator !=(StubToStringStructType left, StubToStringStructType right)
            =>
            left.Equals(right) is false;

        public override bool Equals(object? obj)
            =>
            obj is StubToStringStructType other && Equals(other);

        public override int GetHashCode()
            =>
            HashCode.Combine(
                typeof(StubToStringStructType),
                toStringValue is not null ? StringEquality.GetHashCode(toStringValue) : 0);
        
        private static StringComparer StringEquality
            =>
            StringComparer.InvariantCulture;
    }
}