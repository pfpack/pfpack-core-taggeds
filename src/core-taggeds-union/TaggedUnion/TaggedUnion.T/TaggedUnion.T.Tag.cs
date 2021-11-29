namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    private enum Tag
    {
        First = 1,
        Second = 2
    }
}
