#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static bool Equals(TaggedUnion<TFirst, TSecond> unionA, TaggedUnion<TFirst, TSecond> unionB)
            =>
            Box.Equals(unionA.boxFirst, unionB.boxFirst) &&
            Box.Equals(unionA.boxSecond, unionB.boxSecond);

        public static bool operator ==(TaggedUnion<TFirst, TSecond> unionA, TaggedUnion<TFirst, TSecond> unionB)
            =>
            Equals(unionA, unionB);

        public static bool operator !=(TaggedUnion<TFirst, TSecond> unionA, TaggedUnion<TFirst, TSecond> unionB)
            =>
            Equals(unionA, unionB) is false;

        public bool Equals(TaggedUnion<TFirst, TSecond> other)
            =>
            Equals(this, other);

        public override bool Equals(object? obj)
            =>
            obj is TaggedUnion<TFirst, TSecond> other &&
            Equals(this, other);

        public override int GetHashCode()
            =>
            HashCode.Combine(EqualityContract, boxFirst, boxSecond);

        private static Type EqualityContract
            =>
            typeof(TaggedUnion<TFirst, TSecond>);
    }
}
