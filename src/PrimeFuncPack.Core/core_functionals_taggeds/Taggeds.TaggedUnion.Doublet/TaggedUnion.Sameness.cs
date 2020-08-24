#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static bool Same(TaggedUnion<TFirst, TSecond> unionA, TaggedUnion<TFirst, TSecond> unionB)
            =>
            Box.Same(unionA.boxFirst, unionB.boxFirst) &&
            Box.Same(unionA.boxSecond, unionB.boxSecond);

        public bool Same(TaggedUnion<TFirst, TSecond> other)
            =>
            Same(this, other);

        public int GetSamenessHashCode()
            =>
            HashCode.Combine(SamenessContract, GetBoxSamenessHashCode(boxFirst), GetBoxSamenessHashCode(boxSecond));

        private static Type SamenessContract => typeof(TaggedUnion<TFirst, TSecond>);

        private static int GetBoxSamenessHashCode<TCategory>(in Box<TCategory>? box)
            =>
            box switch { not null => box.GetSamenessHashCode(), _ => default };
    }
}
