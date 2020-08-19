#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private Optional<TFirst> First() => Optional.Wrap(boxFirst);

        private Optional<TSecond> Second() => Optional.Wrap(boxSecond);
    }
}
