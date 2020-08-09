#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static bool Equals(in Optional<T> optionalA, in Optional<T> optionalB)
            =>
            Box<T>.Equals(optionalA.box, optionalB.box);

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
        {
            var result = new HashCode();

            result.Add(GetType());

            if (box is not null)
            {
                result.Add(box);
            }

            return result.ToHashCode();
        }
    }
}
