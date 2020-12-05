#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static bool Equals(Optional<T> optionalA, Optional<T> optionalB)
            =>
            optionalA.box == optionalB.box;

        public static bool operator ==(Optional<T> optionalA, Optional<T> optionalB)
            =>
            Equals(optionalA, optionalB);

        public static bool operator !=(Optional<T> optionalA, Optional<T> optionalB)
            =>
            Equals(optionalA, optionalB) is false;

        public bool Equals(Optional<T> other)
            =>
            Equals(this, other);

        public override bool Equals(object? obj)
            =>
            obj is Optional<T> other &&
            Equals(this, other);

        public override int GetHashCode()
            =>
            HashCode.Combine(
                EqualityContract,
                box.GetHashCode());

        private static Type EqualityContract
            =>
            typeof(Optional<T>);
    }
}
