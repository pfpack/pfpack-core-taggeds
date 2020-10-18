#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Box<T>
    {
        public static bool Same([AllowNull] Box<T> boxA, [AllowNull] Box<T> boxB)
            =>
            ReferenceEquals(boxA, boxB);

        public bool Same([AllowNull] Box<T> other)
            =>
            Same(this, other);

        public int GetSamenessHashCode()
            =>
            base.GetHashCode();
    }
}
