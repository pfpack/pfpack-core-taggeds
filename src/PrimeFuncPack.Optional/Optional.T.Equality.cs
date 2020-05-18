#nullable enable

using PrimeFuncPack.Extensions.Primitives;

namespace PrimeFuncPack
{
    partial struct Optional<T>
    {
        public static bool Equals(in Optional<T> optionalA, in Optional<T> optionalB)
            =>
            Box.Equals(optionalA.box, optionalB.box);

        public static bool operator ==(in Optional<T> optionalA, in Optional<T> optionalB)
            =>
            Equals(optionalA, optionalB);

        public static bool operator !=(in Optional<T> optionalA, in Optional<T> optionalB)
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
            box switch { object present => present.GetHashCode(), _ => default };
    }
}
