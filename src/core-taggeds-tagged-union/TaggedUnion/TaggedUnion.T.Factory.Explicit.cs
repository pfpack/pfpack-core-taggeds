#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static TaggedUnion<TFirst, TSecond> First(TFirst first)
            =>
            new(first);

        public static TaggedUnion<TFirst, TSecond> Second(TSecond second)
            =>
            new(second);
    }
}
