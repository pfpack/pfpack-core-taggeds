#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion(in TFirst first)
        {
            this.first = Optional<TFirst>.Present(first);
            second = default;
        }

        public TaggedUnion(in TSecond second)
        {
            this.second = Optional<TSecond>.Present(second);
            first = default;
        }
    }
}
