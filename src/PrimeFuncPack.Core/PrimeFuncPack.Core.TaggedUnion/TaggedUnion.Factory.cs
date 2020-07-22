#nullable enable

namespace System
{
    partial struct TaggedUnion<TTag, TFirst, TSecond>
    {
        public static TaggedUnion<TTag, TFirst, TSecond> CreateFirst(in TFirst first)
            =>
            new TaggedUnion<TTag, TFirst, TSecond>(first: first);

        public static TaggedUnion<TTag, TFirst, TSecond> CreateSecond(in TSecond second)
            =>
            new TaggedUnion<TTag, TFirst, TSecond>(second: second);

        private TaggedUnion(in TFirst first)
        {
            boxFirst = first;
            boxSecond = null;
        }

        private TaggedUnion(in TSecond second)
        {
            boxFirst = null;
            boxSecond = second;
        }
    }
}
