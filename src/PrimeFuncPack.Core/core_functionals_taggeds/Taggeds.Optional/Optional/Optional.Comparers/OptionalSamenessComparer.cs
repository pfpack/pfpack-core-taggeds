#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class OptionalSamenessComparer<T> : IEqualityComparer<Optional<T>>
    {
        public bool Equals(Optional<T> optionalA, Optional<T> optionalB)
            =>
            Optional<T>.Same(optionalA, optionalB);

        public int GetHashCode(Optional<T> optional)
            =>
            optional.GetSamenessHashCode();

        public static OptionalSamenessComparer<T> Default => OptionalSamenessComparerDefault<T>.Value;
    }

    internal static class OptionalSamenessComparerDefault<T>
    {
        public static readonly OptionalSamenessComparer<T> Value = new OptionalSamenessComparer<T>();
    }
}
