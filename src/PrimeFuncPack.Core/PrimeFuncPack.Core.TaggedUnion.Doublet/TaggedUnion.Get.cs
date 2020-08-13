#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private Optional<TFirst> First() => Optional.WrapBox(boxFirst);

        private Optional<TSecond> Second() => Optional.WrapBox(boxSecond);
    }
}
