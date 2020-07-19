#nullable enable

namespace System
{
    public readonly partial struct Optional<T> :
        IEquatable<Optional<T>>,
        ISamenessEquatable<Optional<T>>
    {
        internal readonly Box<T>? box;

        public bool IsPresent => box is object;

        public bool IsAbsent => box is null;

        public override string ToString()
            =>
            box?.ToString() ?? string.Empty;
    }
}
