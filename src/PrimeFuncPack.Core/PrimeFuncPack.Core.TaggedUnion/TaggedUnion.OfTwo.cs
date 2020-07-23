#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TTag, TFirst, TSecond>
        where TFirst : TTag
        where TSecond : TTag
    {
        private readonly Box<TFirst>? boxFirst;

        private readonly Box<TSecond>? boxSecond;

        public bool IsInitialized => IsFirst || IsSecond;

        public bool IsFirst => boxFirst is object;

        public bool IsSecond => boxSecond is object;

        public TTag GetTag()
        {
            var @this = this;

            return default(Optional<TTag>)
                .Or(() => @this.TryGetFirst().Map<TTag>(value => value))
                .Or(() => @this.TryGetSecond().Map<TTag>(value => value))
                .OrThrow(CreateNotInitializedException);
        }

        public Optional<TFirst> TryGetFirst() => TryGetItem(boxFirst);

        public Optional<TSecond> TryGetSecond() => TryGetItem(boxSecond);

        private Optional<TItem> TryGetItem<TItem>(in Box<TItem>? box) => IsInitialized switch
        {
            true => box.ToOptional(),
            _ => throw CreateNotInitializedException()
        };
    }
}
