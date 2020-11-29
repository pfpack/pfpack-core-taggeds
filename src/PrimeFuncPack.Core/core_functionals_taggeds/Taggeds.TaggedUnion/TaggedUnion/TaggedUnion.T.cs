#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TFirst, TSecond> : IEquatable<TaggedUnion<TFirst, TSecond>>
    {
        private readonly Optional<TFirst> first;

        private readonly Optional<TSecond> second;

        public bool IsInitialized
            =>
            first.IsPresent ||
            second.IsPresent;

        public bool IsFirst
            =>
            first.IsPresent;

        public bool IsSecond
            =>
            second.IsPresent;
    }
}
