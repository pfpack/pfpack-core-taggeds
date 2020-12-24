#nullable enable

namespace System
{
    partial struct Box<T>
    {
        public Box(T value)
            =>
            Value = value;

        public static implicit operator Box<T>(T value)
            =>
            new(value);
    }
}
