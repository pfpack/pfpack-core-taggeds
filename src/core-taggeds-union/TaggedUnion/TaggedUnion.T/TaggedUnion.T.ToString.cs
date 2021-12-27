namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public override string ToString()
        =>
        InnerFold(
            InternalToString<TFirst, TSecond>.TaggedUnionFirst,
            InternalToString<TFirst, TSecond>.TaggedUnionSecond,
            InternalToString<TFirst, TSecond>.TaggedUnionNone);
}
