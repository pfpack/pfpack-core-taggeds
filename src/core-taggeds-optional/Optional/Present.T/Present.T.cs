#nullable enable

namespace System
{
    public partial struct Present<T> : IEquatable<Present<T>>
    {
        private readonly T value;

        public T Value => value;

        public Present(T value)
            =>
            this.value = value;

        public static Present<T> From(T value)
            =>
            new(value);

        public static implicit operator Present<T>(T value)
            =>
            new(value);

        public static explicit operator T(Present<T> present)
            =>
            present.value;
    }
}
