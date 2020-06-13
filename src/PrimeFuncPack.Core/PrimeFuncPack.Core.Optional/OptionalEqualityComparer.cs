#nullable enable

using System.Collections.Generic;

namespace PrimeFuncPack
{
    public sealed class OptionalEqualityComparer<T> : IEqualityComparer<Optional<T>>
    {
        public bool Equals(Optional<T> x, Optional<T> y)
            =>
            Optional<T>.Equals(x, y);

        public int GetHashCode(Optional<T> obj)
            =>
            obj.GetHashCode();

        public static OptionalEqualityComparer<T> Default => OptionalEqualityComparerDefault<T>.Value;
    }

    internal static class OptionalEqualityComparerDefault<T>
    {
        public static readonly OptionalEqualityComparer<T> Value = new OptionalEqualityComparer<T>();
    }
}
