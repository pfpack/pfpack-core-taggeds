#nullable enable

namespace System
{
    partial class TaggedUnion
    {
        public static bool Same<TFirst, TSecond>(in TaggedUnion<TFirst, TSecond> unionA, in TaggedUnion<TFirst, TSecond> unionB)
            =>
            TaggedUnion<TFirst, TSecond>.Same(unionA, unionB);
    }
}
