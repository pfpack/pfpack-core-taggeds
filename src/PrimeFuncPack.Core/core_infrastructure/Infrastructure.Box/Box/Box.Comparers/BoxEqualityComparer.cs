#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System
{
    public sealed class BoxEqualityComparer<T> : IEqualityComparer<Box<T>>
    {
        public bool Equals([AllowNull] Box<T> boxA, [AllowNull] Box<T> boxB)
            =>
            Box<T>.Equals(boxA, boxB);

        public int GetHashCode([DisallowNull] Box<T> box) => box switch
        {
            not null => box.GetHashCode(),
            _ => throw new ArgumentNullException(nameof(box))
        };

        public static BoxEqualityComparer<T> Default => BoxEqualityComparerDefault<T>.Value;
    }

    internal static class BoxEqualityComparerDefault<T>
    {
        public static readonly BoxEqualityComparer<T> Value = new BoxEqualityComparer<T>();
    }
}
