#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial record Box<T>
    {
        public static bool Equals([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            boxA is null && boxB is null ||
            boxA is not null && boxA.Equals(boxB) ||
            boxB is not null && boxB.Equals(boxA);

        public static bool operator ==([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            Equals(boxA, boxB);

        public static bool operator !=([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            Equals(boxA, boxB) is false;
    }
}
