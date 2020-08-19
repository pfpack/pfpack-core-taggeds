#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static TaggedUnion<TFirst, TSecond> CreateFirst(in TFirst first)
            =>
            new TaggedUnion<TFirst, TSecond>(first: first);

        public static TaggedUnion<TFirst, TSecond> CreateSecond(in TSecond second)
            =>
            new TaggedUnion<TFirst, TSecond>(second: second);
    }
}
