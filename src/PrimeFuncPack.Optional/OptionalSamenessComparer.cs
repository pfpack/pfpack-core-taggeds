#nullable enable

using PrimeFuncPack.Internal;
using System.Collections.Generic;

namespace PrimeFuncPack
{
    public sealed class OptionalSamenessComparer<T> : IEqualityComparer<Optional<T>>
    {
        public bool Equals(Optional<T> x, Optional<T> y)
            =>
            Optional.Same(x, y);

        public int GetHashCode(Optional<T> obj)
            =>
            obj.SamenessHashCode();

        public static OptionalSamenessComparer<T> Default => OptionalSamenessComparerDefault<T>.Value;
    }
}
