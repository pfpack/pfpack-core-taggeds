#nullable enable

namespace System
{
    public sealed partial class Box<T> :
        IEquatable<Box<T>>,
        ISamenessEquatable<Box<T>>
    {
        public T Value { get; }

        public static implicit operator T(in Box<T> box)
            =>
            box.Value;

        public override string ToString()
            =>
            Value.ToStringOrEmpty();
    }
}
