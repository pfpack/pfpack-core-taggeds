namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TaggedUnion(TFirst first)
        =>
        (this.first, tag, second) = (first, Tag.First, default!);

    public TaggedUnion(TSecond second)
        =>
        (this.second, tag, first) = (second, Tag.Second, default!);
}
