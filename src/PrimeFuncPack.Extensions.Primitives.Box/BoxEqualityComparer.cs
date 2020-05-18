#nullable enable

using PrimeFuncPack.Extensions.Primitives.Internal;
using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.Primitives
{
    public sealed class BoxEqualityComparer<T> : IEqualityComparer<Box<T>>
    {
        public bool Equals(Box<T>? x, Box<T>? y)
            =>
            Box.Equals(x, y);

        public int GetHashCode(Box<T>? obj)
            =>
            obj?.GetHashCode() ??
            throw new ArgumentNullException(nameof(obj));

        public static BoxEqualityComparer<T> Default => BoxEqualityComparerDefault<T>.Value;
    }
}
