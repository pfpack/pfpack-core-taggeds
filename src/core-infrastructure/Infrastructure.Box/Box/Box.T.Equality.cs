#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct Box<T>
    {
        public static bool Equals(Box<T> boxA, Box<T> boxB)
            =>
            ValueEqualityComparer.Equals(boxA, boxB);

        public static bool operator ==(Box<T> boxA, Box<T> boxB)
            =>
            Equals(boxA, boxB);

        public static bool operator !=(Box<T> boxA, Box<T> boxB)
            =>
            Equals(boxA, boxB) is false;

        public bool Equals(Box<T> other)
            =>
            Equals(this, other);

        public override bool Equals(object? obj)
            =>
            obj is Box<T> other &&
            Equals(this, other);

        public override int GetHashCode()
            =>
            HashCode.Combine(
                EqualityContract,
                GetValueHashCode());

        private int GetValueHashCode()
            =>
            Value switch
            {
                not null => ValueEqualityComparer.GetHashCode(Value),
                _ => default
            };

        private static IEqualityComparer<T> ValueEqualityComparer
            =>
            EqualityComparer<T>.Default;

        private static Type EqualityContract
            =>
            typeof(Box<T>);
    }
}
