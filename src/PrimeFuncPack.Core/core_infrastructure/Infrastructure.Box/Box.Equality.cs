#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Box
    {
        public static bool Equals<T>([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            Box<T>.Equals(boxA, boxB);
    }
}
