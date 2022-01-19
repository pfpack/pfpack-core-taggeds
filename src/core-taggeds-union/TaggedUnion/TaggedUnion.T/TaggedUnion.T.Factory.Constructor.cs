namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TaggedUnion(TFirst first)
        =>
        (this.first, tag, second) = (first, InternalTag.First, default!);

    public TaggedUnion(TSecond second)
        =>
        (this.second, tag, first) = (second, InternalTag.Second, default!);
}
