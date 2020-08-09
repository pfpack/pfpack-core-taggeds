#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TFirst, TSecond>
    {
        private readonly Box<TFirst>? boxFirst;

        private readonly Box<TSecond>? boxSecond;

        private bool HasValidInvariant => IsFirst ^ IsSecond;

        public bool IsInitialized => IsFirst || IsSecond;

        public bool IsFirst => boxFirst is not null;

        public bool IsSecond => boxSecond is not null;
    }
}
