#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion(TFirst first)
        {
            this.first = Optional<TFirst>.Present(first);
            second = default;
        }

        public TaggedUnion(TSecond second)
        {
            this.second = Optional<TSecond>.Present(second);
            first = default;
        }
    }
}
