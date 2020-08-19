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

        private Optional(in T value)
            =>
            box = value;

        private Optional(in Box<T>? box)
            =>
            this.box = box;
    }
}
