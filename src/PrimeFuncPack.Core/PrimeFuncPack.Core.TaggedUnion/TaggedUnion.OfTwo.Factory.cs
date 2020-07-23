#nullable enable

namespace System
{
    partial struct TaggedUnion<TTag, TFirst, TSecond>
    {
        public static TaggedUnion<TTag, TFirst, TSecond> CreateFirst(in TFirst first)
        {
            var result = new TaggedUnion<TTag, TFirst, TSecond>(first: first);
            AssertInvariant(result);
            return result;
        }

        public static TaggedUnion<TTag, TFirst, TSecond> CreateSecond(in TSecond second)
        {
            var result = new TaggedUnion<TTag, TFirst, TSecond>(second: second);
            AssertInvariant(result);
            return result;
        }

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

        private static Unit AssertInvariant(in TaggedUnion<TTag, TFirst, TSecond> tagged)
            =>
            tagged.IsInitializedProperly switch
            {
                true => default,
                _ => throw new InvalidOperationException("The tagged union is not initialized properly.")
            };
    }
}
