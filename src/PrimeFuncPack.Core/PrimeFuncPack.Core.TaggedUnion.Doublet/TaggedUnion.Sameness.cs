#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static bool Same(in TaggedUnion<TFirst, TSecond> unionA, in TaggedUnion<TFirst, TSecond> unionB)
            =>
            Box.Same(unionA.boxFirst, unionB.boxFirst) &&
            Box.Same(unionA.boxSecond, unionB.boxSecond);

        public bool Same(in TaggedUnion<TFirst, TSecond> other)
            =>
            Same(this, other);

        public int GetSamenessHashCode()
            =>
            HashCode.Combine(SamenessContract, GetFirstSamenessHashCode(), GetSecondSamenessHashCode());

        private static Type SamenessContract => typeof(TaggedUnion<TFirst, TSecond>);

        private int GetFirstSamenessHashCode() => GetBoxSamenessHashCode(boxFirst);

        private int GetSecondSamenessHashCode() => GetBoxSamenessHashCode(boxSecond);

        private static int GetBoxSamenessHashCode<TCategory>(in Box<TCategory>? box)
            =>
            box switch { not null => box.GetSamenessHashCode(), _ => default };
    }
}
