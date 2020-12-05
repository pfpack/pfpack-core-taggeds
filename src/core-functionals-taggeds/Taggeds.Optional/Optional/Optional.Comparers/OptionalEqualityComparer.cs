#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class OptionalEqualityComparer<T> : IEqualityComparer<Optional<T>>
    {
        public bool Equals(Optional<T> optionalA, Optional<T> optionalB)
            =>
            Optional<T>.Equals(optionalA, optionalB);

        public int GetHashCode(Optional<T> optional)
            =>
            optional.GetHashCode();

        public static OptionalEqualityComparer<T> Default
            =>
            OptionalEqualityComparerDefault<T>.Value;
    }

    internal static class OptionalEqualityComparerDefault<T>
    {
        public static readonly OptionalEqualityComparer<T> Value = new();
    }
}
