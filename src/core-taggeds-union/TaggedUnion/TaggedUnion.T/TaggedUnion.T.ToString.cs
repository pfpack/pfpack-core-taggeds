namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public override string ToString()
        =>
        InnerToString();
}
