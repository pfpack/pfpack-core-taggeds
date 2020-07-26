#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private Optional<TFirst> TryGetFirst() => TryGet(boxFirst);

        private Optional<TSecond> TryGetSecond() => TryGet(boxSecond);

        private Optional<TItem> TryGet<TItem>(in Box<TItem>? box) => IsInitialized switch
        {
            true => box.ToOptional(),
            _ => throw CreateNotInitializedException()
        };
    }
}
