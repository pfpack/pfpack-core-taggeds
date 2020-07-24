#nullable enable

namespace System
{
    partial struct TaggedUnion<TTag, TFirst, TSecond>
    {
        public static TaggedUnion<TTag, TFirst, TSecond> CreateFirst(in TFirst first)
            =>
            new TaggedUnion<TTag, TFirst, TSecond>(first: first)
            .AssertInvariant();

        public static TaggedUnion<TTag, TFirst, TSecond> CreateSecond(in TSecond second)
            =>
            new TaggedUnion<TTag, TFirst, TSecond>(second: second)
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

        private TaggedUnion<TTag, TFirst, TSecond> AssertInvariant() => IsProperInvariant switch
        {
            true => this,
            _ => throw new InvalidOperationException("The tagged union is not initialized properly.")
        };
    }
}
