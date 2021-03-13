#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TFirst, TSecond> : IEquatable<TaggedUnion<TFirst, TSecond>>
    {
        private readonly bool isInitialized;

        private readonly Optional<TFirst> first;

        private readonly Optional<TSecond> second;

        public bool IsInitialized
            =>
            isInitialized;

        public bool IsFirst
            =>
            first.IsPresent;

        public bool IsSecond
            =>
            second.IsPresent;
    }
}
