#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static TaggedUnion<TFirst, TSecond> First(TFirst first)
            =>
            new TaggedUnion<TFirst, TSecond>(first);

        public static TaggedUnion<TFirst, TSecond> Second(TSecond second)
            =>
            new TaggedUnion<TFirst, TSecond>(second);
    }
}
