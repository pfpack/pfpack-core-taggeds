#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Box
    {
        public static bool Equals<T>([AllowNull] Box<T> boxA, [AllowNull] Box<T> boxB)
            =>
            Box<T>.Equals(boxA, boxB);
    }
}
