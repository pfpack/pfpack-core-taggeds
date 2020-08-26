#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System
{
    public sealed class BoxSamenessComparer<T> : IEqualityComparer<Box<T>>
    {
        public bool Equals([AllowNull] Box<T> x, [AllowNull] Box<T> y)
            =>
            Box<T>.Same(x, y);

        public int GetHashCode([DisallowNull] Box<T> box) => box switch
        {
            not null => box.GetSamenessHashCode(),
            _ => throw new ArgumentNullException(nameof(box))
        };

        public static BoxSamenessComparer<T> Default => BoxSamenessComparerDefault<T>.Value;
    }

    internal static class BoxSamenessComparerDefault<T>
    {
        public static readonly BoxSamenessComparer<T> Value = new BoxSamenessComparer<T>();
    }
}
