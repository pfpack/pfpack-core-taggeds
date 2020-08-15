#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial record Box<T>
    {
        public static bool Same([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            ReferenceEquals(boxA, boxB);

        public bool Same([AllowNull] in Box<T> other)
            =>
            Same(this, other);

        public int GetSamenessHashCode()
            =>
            base.GetHashCode();
    }
}
