#nullable enable

namespace System
{
    partial record Box<T>
    {
        public Box(in T value)
            =>
            Value = value;

        public static implicit operator Box<T>(in T value)
            =>
            new Box<T>(value);
    }
}
