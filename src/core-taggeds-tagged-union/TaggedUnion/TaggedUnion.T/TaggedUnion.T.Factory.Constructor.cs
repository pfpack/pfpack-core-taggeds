#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion(TFirst first)
        {
            tag = Tag.First;
            this.first = first;
            second = default!;
        }

        public TaggedUnion(TSecond second)
        {
            tag = Tag.Second;
            first = default!;
            this.second = second;
        }
    }
}
