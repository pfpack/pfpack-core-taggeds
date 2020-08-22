#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Box
    {
        public static bool Same<T>([AllowNull] Box<T> boxA, [AllowNull] Box<T> boxB)
            =>
            Box<T>.Same(boxA, boxB);
    }
}
