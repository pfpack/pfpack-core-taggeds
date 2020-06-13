#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class OptionalSamenessComparer<T> : IEqualityComparer<Optional<T>>
    {
        public bool Equals(Optional<T> x, Optional<T> y)
            =>
            Optional<T>.Same(x, y);

        public int GetHashCode(Optional<T> obj)
            =>
            obj.GetSamenessHashCode();

        public static OptionalSamenessComparer<T> Default => OptionalSamenessComparerDefault<T>.Value;
    }

    internal static class OptionalSamenessComparerDefault<T>
    {
        public static readonly OptionalSamenessComparer<T> Value = new OptionalSamenessComparer<T>();
    }
}
