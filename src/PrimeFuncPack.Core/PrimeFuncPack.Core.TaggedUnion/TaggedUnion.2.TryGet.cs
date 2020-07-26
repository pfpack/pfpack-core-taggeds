#nullable enable

namespace System
{
    partial struct TaggedUnion<TTag, TFirst, TSecond>
    {
        public Optional<TFirst> TryGetFirst() => TryGetItem(boxFirst);

        public Optional<TSecond> TryGetSecond() => TryGetItem(boxSecond);

        private Optional<TItem> TryGetItem<TItem>(in Box<TItem>? box) => IsInitialized switch
        {
            true => box.ToOptional(),
            _ => throw CreateNotInitializedException()
        };
    }
}
