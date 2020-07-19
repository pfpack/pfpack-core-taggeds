#nullable enable

namespace System
{
    public readonly partial struct TaggedUnion<TFirst, TSecond>
    {
        private readonly Box<TFirst>? boxFirst;

        private readonly Box<TSecond>? boxSecond;

        public bool IsInitialized => IsFirst || IsSecond;

        public bool IsFirst => boxFirst is object;

        public bool IsSecond => boxSecond is object;

        public Optional<TFirst> TryGetFirst() => boxFirst switch
        {
            null => default,
            var present => Optional<TFirst>.Present(present)
        };

        public Optional<TSecond> TryGetSecond() => boxSecond switch
        {
            null => default,
            var present => Optional<TSecond>.Present(present)
        };
    }
}
