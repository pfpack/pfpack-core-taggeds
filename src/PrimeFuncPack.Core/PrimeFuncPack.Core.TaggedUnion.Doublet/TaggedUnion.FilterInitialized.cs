#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public Optional<TaggedUnion<TFirst, TSecond>> FilterInitialized()
            =>
            IsInitialized switch
            {
                true => Optional.Present(this),
                _ => default
            };
    }
}
