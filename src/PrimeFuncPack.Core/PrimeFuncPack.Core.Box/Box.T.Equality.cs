#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Box<T>
    {
        public static bool Equals([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            ReferenceEquals(boxA, boxB) ||
            boxA is object &&
            boxB is object &&
            EqualityComparer<T>.Default.Equals(boxA, boxB);

        public static bool operator ==([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            Equals(boxA, boxB);

        public static bool operator !=([AllowNull] in Box<T> boxA, [AllowNull] in Box<T> boxB)
            =>
            Equals(boxA, boxB) is false;

        public bool Equals([AllowNull] Box<T> other)
            =>
            Equals(this, other);

        public override bool Equals(object? obj)
            =>
            obj is Box<T> other &&
            Equals(this, other);

        public override int GetHashCode()
            =>
            Value switch { null => default, var present => present.GetHashCode() };
    }
}
