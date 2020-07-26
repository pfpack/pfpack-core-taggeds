#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private Optional<TFirst> TryGetFirst() => TryGetItem(boxFirst);

        private Optional<TSecond> TryGetSecond() => TryGetItem(boxSecond);

        private Optional<TItem> TryGetItem<TItem>(in Box<TItem>? box) => IsInitialized switch
        {
            true => box.ToOptional(),
            _ => throw CreateNotInitializedException()
        };
    }
}
