#nullable enable

namespace System
{
    public sealed partial class Box<T> : IEquatable<Box<T>?>, ISamenessPossessor<Box<T>?>
    {
        public T Value { get; }

        public static implicit operator T(in Box<T> box)
            =>
            box.Value;

        public override string? ToString()
            =>
            Value switch { null => string.Empty, var present => present.ToString() };
    }
}
