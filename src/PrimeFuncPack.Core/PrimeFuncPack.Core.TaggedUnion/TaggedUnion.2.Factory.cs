#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static TaggedUnion<TFirst, TSecond> CreateFirst(in TFirst first)
            =>
            new TaggedUnion<TFirst, TSecond>(first: first)
            .AssertInvariant();

        public static TaggedUnion<TFirst, TSecond> CreateSecond(in TSecond second)
            =>
            new TaggedUnion<TFirst, TSecond>(second: second)
            .AssertInvariant();

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

        private TaggedUnion<TFirst, TSecond> AssertInvariant() => HasValidInvariant switch
        {
            true => this,
            _ => throw CreateExpectedValidInvariantException()
        };
    }
}
