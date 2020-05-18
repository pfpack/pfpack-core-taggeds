#nullable enable

using PrimeFuncPack.Extensions.Primitives.Internal;
using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.Primitives
{
    public sealed class BoxSamenessComparer<T> : IEqualityComparer<Box<T>>
    {
        public bool Equals(Box<T>? x, Box<T>? y)
            =>
            Box.Same(x, y);

        public int GetHashCode(Box<T>? obj)
            =>
            obj?.SamenessHashCode() ??
            throw new ArgumentNullException(nameof(obj));

        public static BoxSamenessComparer<T> Default => BoxSamenessComparerDefault<T>.Value;
    }
}
