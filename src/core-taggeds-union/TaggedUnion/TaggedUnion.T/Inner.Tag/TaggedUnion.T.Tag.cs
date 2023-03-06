namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    private enum Tag
    {
        None,
        First,
        Second
    }
}
