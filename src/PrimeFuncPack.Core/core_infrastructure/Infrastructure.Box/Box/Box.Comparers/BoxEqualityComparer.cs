#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class BoxEqualityComparer<T> : IEqualityComparer<Box<T>>
    {
        public bool Equals(Box<T> boxA, Box<T> boxB)
            =>
            Box<T>.Equals(boxA, boxB);

        public int GetHashCode(Box<T> box)
            =>
            box.GetHashCode();

        public static BoxEqualityComparer<T> Default
            =>
            BoxEqualityComparerDefault<T>.Value;
    }

    internal static class BoxEqualityComparerDefault<T>
    {
        public static readonly BoxEqualityComparer<T> Value = new();
    }
}
