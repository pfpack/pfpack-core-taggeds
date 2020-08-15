#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class TaggedUnionEqualityComparer<TFirst, TSecond> : IEqualityComparer<TaggedUnion<TFirst, TSecond>>
    {
        public bool Equals(TaggedUnion<TFirst, TSecond> x, TaggedUnion<TFirst, TSecond> y)
            =>
            TaggedUnion<TFirst, TSecond>.Equals(x, y);

        public int GetHashCode(TaggedUnion<TFirst, TSecond> obj)
            =>
            obj.GetHashCode();

        public static TaggedUnionEqualityComparer<TFirst, TSecond> Default => TaggedUnionEqualityComparerDefault<TFirst, TSecond>.Value;
    }

    internal static class TaggedUnionEqualityComparerDefault<TFirst, TSecond>
    {
        public static readonly TaggedUnionEqualityComparer<TFirst, TSecond> Value = new TaggedUnionEqualityComparer<TFirst, TSecond>();
    }
}
