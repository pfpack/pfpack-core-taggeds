#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class BoxSamenessComparer<T> : IEqualityComparer<Box<T>?>
    {
        public bool Equals(Box<T>? x, Box<T>? y)
            =>
            Box<T>.Same(x, y);

        public int GetHashCode(Box<T>? obj) => obj switch
        {
            null => throw new ArgumentNullException(nameof(obj)),
            var value => value.SamenessHashCode()
        };

        public static BoxSamenessComparer<T> Default => BoxSamenessComparerDefault<T>.Value;
    }

    internal static class BoxSamenessComparerDefault<T>
    {
        public static readonly BoxSamenessComparer<T> Value = new BoxSamenessComparer<T>();
    }
}
