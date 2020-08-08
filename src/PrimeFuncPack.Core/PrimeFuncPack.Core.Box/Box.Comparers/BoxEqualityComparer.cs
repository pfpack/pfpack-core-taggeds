#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System
{
    public sealed class BoxEqualityComparer<T> : IEqualityComparer<Box<T>>
    {
        public bool Equals([AllowNull] Box<T> x, [AllowNull] Box<T> y)
            =>
            Box<T>.Equals(x, y);

        public int GetHashCode([DisallowNull] Box<T> obj) => obj switch
        {
            not null => obj.GetHashCode(),
            _ => throw new ArgumentNullException(nameof(obj))
        };

        public static BoxEqualityComparer<T> Default => BoxEqualityComparerDefault<T>.Value;
    }

    internal static class BoxEqualityComparerDefault<T>
    {
        public static readonly BoxEqualityComparer<T> Value = new BoxEqualityComparer<T>();
    }
}
