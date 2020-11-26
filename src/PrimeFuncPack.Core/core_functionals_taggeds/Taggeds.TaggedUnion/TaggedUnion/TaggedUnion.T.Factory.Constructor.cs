#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion(in TFirst first)
        {
            boxFirst = first;
            boxSecond = null;
        }

        public TaggedUnion(in TSecond second)
        {
            boxFirst = null;
            boxSecond = second;
        }
    }
}
