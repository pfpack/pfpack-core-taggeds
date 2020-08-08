#nullable enable

namespace System
{
    public sealed partial record Box<T> : ISamenessEquatable<Box<T>>
    {
        public T Value { get; }

        public static implicit operator T(in Box<T> box)
            =>
            box.Value;

        public override string ToString()
            =>
            Value switch { null => string.Empty, _ => Value.ToString() ?? string.Empty };
    }
}
