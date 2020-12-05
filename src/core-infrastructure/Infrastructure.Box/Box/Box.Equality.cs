#nullable enable

namespace System
{
    partial class Box
    {
        public static bool Equals<T>(Box<T> boxA, Box<T> boxB)
            =>
            Box<T>.Equals(boxA, boxB);
    }
}
