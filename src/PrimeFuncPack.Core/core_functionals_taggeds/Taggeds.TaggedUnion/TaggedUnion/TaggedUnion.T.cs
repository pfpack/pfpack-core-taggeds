#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TFirst, TSecond> : IEquatable<TaggedUnion<TFirst, TSecond>>
    {
        private const string CategoryFirst = "First";

        private const string CategorySecond = "Second";

        private readonly Box<TFirst>? boxFirst;

        private readonly Box<TSecond>? boxSecond;

        public bool IsFirst => boxFirst is not null;

        public bool IsSecond => boxSecond is not null;

        public bool IsInitialized => IsFirst || IsSecond;

        private TaggedUnion(in TFirst first)
        {
            boxFirst = first;
            boxSecond = null;
        }

        private TaggedUnion(in TSecond second)
        {
            boxFirst = null;
            boxSecond = second;
        }

        private Optional<TFirst> First() => ToOptional(boxFirst);

        private Optional<TSecond> Second() => ToOptional(boxSecond);

        private static Optional<T> ToOptional<T>(in Box<T>? box)
            =>
            box switch { not null => Optional<T>.Present(box.Value), _ => Optional<T>.Absent };
    }
}
