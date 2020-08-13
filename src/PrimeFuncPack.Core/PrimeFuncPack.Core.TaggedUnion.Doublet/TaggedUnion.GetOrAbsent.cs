#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private Optional<TFirst> First() => Optional.FromBox(boxFirst);

        private Optional<TSecond> Second() => Optional.FromBox(boxSecond);
    }
}
