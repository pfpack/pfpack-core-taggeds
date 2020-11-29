#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TFirst, TSecond> : IEquatable<TaggedUnion<TFirst, TSecond>>
    {
        private readonly Box<TFirst>? boxFirst;

        private readonly Box<TSecond>? boxSecond;

        public bool IsInitialized
            =>
            IsFirst || IsSecond;

        public bool IsFirst
            =>
            boxFirst is not null;

        public bool IsSecond
            =>
            boxSecond is not null;

        private Optional<TFirst> First()
            =>
            boxFirst.ToOptional();

        private Optional<TSecond> Second()
            =>
            boxSecond.ToOptional();
    }
}
