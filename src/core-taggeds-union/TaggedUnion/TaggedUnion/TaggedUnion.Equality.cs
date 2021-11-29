namespace System;

partial class TaggedUnion
{
    public static bool Equals<TFirst, TSecond>(
        TaggedUnion<TFirst, TSecond> left, TaggedUnion<TFirst, TSecond> right)
        =>
        left.Equals(right);
}
