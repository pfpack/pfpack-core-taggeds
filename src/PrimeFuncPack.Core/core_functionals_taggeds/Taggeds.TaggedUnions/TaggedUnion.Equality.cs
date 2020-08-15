#nullable enable

namespace System
{
    partial class TaggedUnion
    {
        public static bool Equals<TFirst, TSecond>(in TaggedUnion<TFirst, TSecond> unionA, in TaggedUnion<TFirst, TSecond> unionB)
            =>
            TaggedUnion<TFirst, TSecond>.Equals(unionA, unionB);
    }
}
