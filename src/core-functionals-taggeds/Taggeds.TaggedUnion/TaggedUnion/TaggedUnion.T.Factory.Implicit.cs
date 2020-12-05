#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static implicit operator TaggedUnion<TFirst, TSecond>(in TFirst first)
            =>
            new(first);

        public static implicit operator TaggedUnion<TFirst, TSecond>(in TSecond second)
            =>
            new(second);
    }
}
