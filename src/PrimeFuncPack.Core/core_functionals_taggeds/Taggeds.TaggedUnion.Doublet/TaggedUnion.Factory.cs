#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static TaggedUnion<TFirst, TSecond> CreateFirst(TFirst first)
            =>
            new TaggedUnion<TFirst, TSecond>(first: first);

        public static TaggedUnion<TFirst, TSecond> CreateSecond(TSecond second)
            =>
            new TaggedUnion<TFirst, TSecond>(second: second);
    }
}
