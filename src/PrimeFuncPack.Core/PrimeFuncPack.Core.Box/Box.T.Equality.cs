#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial record Box<T>
    {
        private static IEqualityComparer<T> ValueEqualityComparer => EqualityComparer<T>.Default;

        public static bool Equals([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            ReferenceEquals(boxA, boxB) ||
            boxA is not null &&
            boxB is not null &&
            ValueEqualityComparer.Equals(boxA, boxB);

        public static bool operator ==([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            Equals(boxA, boxB);

        public static bool operator !=([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            Equals(boxA, boxB) is false;

        public bool Equals([AllowNull] Box<T> other)
            =>
            Equals(this, other);

        public override int GetHashCode()
        {
            const int factor = -1521134295;

            int result = GetType().GetHashCode();

            unchecked { result *= factor; }

            if (Value is not null)
            {
                unchecked { result += ValueEqualityComparer.GetHashCode(Value); }
            }

            return result;
        }
    }
}
