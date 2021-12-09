namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public static implicit operator TaggedUnion<TFirst, TSecond>(TFirst first)
        =>
        new(first);

    public static implicit operator TaggedUnion<TFirst, TSecond>(TSecond second)
        =>
        new(second);
}
