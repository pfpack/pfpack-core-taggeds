#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TTag, TFirst, TSecond>
        where TFirst : TTag
        where TSecond : TTag
    {
        private readonly Box<TFirst>? boxFirst;

        private readonly Box<TSecond>? boxSecond;

        private bool HasValidInvariant => IsFirst ^ IsSecond;

        public bool IsInitialized => IsFirst || IsSecond;

        public bool IsFirst => boxFirst is object;

        public bool IsSecond => boxSecond is object;

        public Optional<TFirst> TryGetFirst() => TryGetItem(boxFirst);

        public Optional<TSecond> TryGetSecond() => TryGetItem(boxSecond);

        private Optional<TItem> TryGetItem<TItem>(in Box<TItem>? box) => IsInitialized switch
        {
            true => box.ToOptional(),
            _ => throw CreateNotInitializedException()
        };
    }
}
