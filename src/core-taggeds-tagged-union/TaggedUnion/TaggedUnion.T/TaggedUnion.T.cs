#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TFirst, TSecond> : IEquatable<TaggedUnion<TFirst, TSecond>>
    {
        private readonly Tag tag;

        private readonly TFirst first;

        private readonly TSecond second;

        public bool IsInitialized
            =>
            tag != default;

        public bool IsFirst
            =>
            tag == Tag.First;

        public bool IsSecond
            =>
            tag == Tag.Second;
    }
}
