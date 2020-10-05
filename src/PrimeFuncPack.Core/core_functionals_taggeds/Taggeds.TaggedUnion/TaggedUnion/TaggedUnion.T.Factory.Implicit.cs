#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static implicit operator TaggedUnion<TFirst, TSecond>(in TFirst first)
            =>
            First(first);

        public static implicit operator TaggedUnion<TFirst, TSecond>(in TSecond second)
            =>
            Second(second);
    }
}
