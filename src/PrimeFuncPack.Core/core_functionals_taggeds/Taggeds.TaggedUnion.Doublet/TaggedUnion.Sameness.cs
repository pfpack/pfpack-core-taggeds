#nullable enable

namespace System
{
    partial class TaggedUnion
    {
        public static bool Same<TFirst, TSecond>(TaggedUnion<TFirst, TSecond> unionA, TaggedUnion<TFirst, TSecond> unionB)
            =>
            TaggedUnion<TFirst, TSecond>.Same(unionA, unionB);
    }
}
