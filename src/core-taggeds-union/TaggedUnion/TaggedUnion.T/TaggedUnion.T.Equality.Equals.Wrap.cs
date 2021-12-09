namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public static bool Equals(TaggedUnion<TFirst, TSecond> left, TaggedUnion<TFirst, TSecond> right)
        =>
        left.Equals(right);

    public static bool operator ==(TaggedUnion<TFirst, TSecond> left, TaggedUnion<TFirst, TSecond> right)
        =>
        left.Equals(right);

    public static bool operator !=(TaggedUnion<TFirst, TSecond> left, TaggedUnion<TFirst, TSecond> right)
        =>
        left.Equals(right) is false;

    public override bool Equals(object? obj)
        =>
        obj is TaggedUnion<TFirst, TSecond> other &&
        Equals(other);
}
