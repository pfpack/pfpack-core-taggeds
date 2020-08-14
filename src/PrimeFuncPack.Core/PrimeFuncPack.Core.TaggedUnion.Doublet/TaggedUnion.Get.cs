#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private Optional<TFirst> WrapFirst() => Optional.Wrap(boxFirst);

        private Optional<TSecond> WrapSecond() => Optional.Wrap(boxSecond);
    }
}
