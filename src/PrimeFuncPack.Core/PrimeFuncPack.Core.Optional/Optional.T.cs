#nullable enable

namespace System
{
    public readonly partial struct Optional<T> :
        IEquatable<Optional<T>>,
        ISamenessEquatable<Optional<T>>
    {
        private readonly Box<T>? box;

        public bool IsPresent => box is not null;

        public bool IsAbsent => box is null;

        public override string ToString()
            =>
            box switch { null => string.Empty, var present => present.ToString() };
    }
}
