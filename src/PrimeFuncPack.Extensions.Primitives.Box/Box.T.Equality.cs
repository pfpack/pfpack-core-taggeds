#nullable enable

namespace PrimeFuncPack.Extensions.Primitives
{
    partial class Box<T>
    {
        public static bool Equals(in Box<T>? boxA, in Box<T>? boxB)
            =>
            ReferenceEquals(boxA, boxB) ||
            boxA is object &&
            boxB is object &&
            ValueEquals(boxA, boxB);

        public static bool operator ==(in Box<T>? boxA, in Box<T>? boxB)
            =>
            Equals(boxA, boxB);

        public static bool operator !=(in Box<T>? boxA, in Box<T>? boxB)
            =>
            Equals(boxA, boxB) is false;

        public bool Equals(Box<T>? other)
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
