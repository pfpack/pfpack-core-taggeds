#nullable enable

using static System.Optional;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion(TFirst first)
        {
            this.first = Present(first);
            second = default;
            isInitialized = true;
        }

        public TaggedUnion(TSecond second)
        {
            this.second = Present(second);
            first = default;
            isInitialized = true;
        }
    }
}
