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
            const int factor = -1521134295;

            int result = GetType().GetHashCode();

            unchecked { result *= factor; }

            if (box is not null)
            {
                unchecked { result += box.GetHashCode(); }
            }

            return result;
        }
    }
}
