#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TFirst, TSecond> :
        IEquatable<TaggedUnion<TFirst, TSecond>>,
        ISamenessEquatable<TaggedUnion<TFirst, TSecond>>
    {
        private const string CategoryFirst = nameof(TFirst);

        private const string CategorySecond = nameof(TSecond);

        private readonly Box<TFirst>? boxFirst;

        private readonly Box<TSecond>? boxSecond;

        public bool IsFirst => boxFirst is not null;

        public bool IsSecond => boxSecond is not null;

        public bool IsInitialized => IsFirst || IsSecond;
    }
}
