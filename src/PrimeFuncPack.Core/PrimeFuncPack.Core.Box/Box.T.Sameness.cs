#nullable enable

namespace System
{
    partial class Box<T>
    {
        public static bool Same(in Box<T>? boxA, in Box<T>? boxB)
            =>
            ReferenceEquals(boxA, boxB);

        public bool Same(in Box<T>? other)
            =>
            Same(this, other);

        public int GetSamenessHashCode()
            =>
            base.GetHashCode();
    }
}
