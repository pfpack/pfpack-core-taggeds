#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class TaggedUnionSamenessComparer<TFirst, TSecond> : IEqualityComparer<TaggedUnion<TFirst, TSecond>>
    {
        public bool Equals(TaggedUnion<TFirst, TSecond> x, TaggedUnion<TFirst, TSecond> y)
            =>
            TaggedUnion<TFirst, TSecond>.Same(x, y);

        public int GetHashCode(TaggedUnion<TFirst, TSecond> obj)
            =>
            obj.GetSamenessHashCode();

        public static TaggedUnionSamenessComparer<TFirst, TSecond> Default => TaggedUnionSamenessComparerDefault<TFirst, TSecond>.Value;
    }

    internal static class TaggedUnionSamenessComparerDefault<TFirst, TSecond>
    {
        public static readonly TaggedUnionSamenessComparer<TFirst, TSecond> Value = new TaggedUnionSamenessComparer<TFirst, TSecond>();
    }
}
