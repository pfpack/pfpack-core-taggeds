#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class BoxEqualityComparer<T> : IEqualityComparer<Box<T>?>
    {
        public bool Equals(Box<T>? x, Box<T>? y)
            =>
            Box<T>.Equals(x, y);

        public int GetHashCode(Box<T>? obj) => obj switch
        {
            null => throw new ArgumentNullException(nameof(obj)),
            var present => present.GetHashCode()
        };

        public static BoxEqualityComparer<T> Default => BoxEqualityComparerDefault<T>.Value;
    }

    internal static class BoxEqualityComparerDefault<T>
    {
        public static readonly BoxEqualityComparer<T> Value = new BoxEqualityComparer<T>();
    }
}
