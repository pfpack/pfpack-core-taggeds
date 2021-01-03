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
        }

        public TaggedUnion(TSecond second)
        {
            this.second = Present(second);
            first = default;
        }
    }
}
