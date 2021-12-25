namespace System;

public readonly partial struct TaggedUnion<TFirst, TSecond> : IEquatable<TaggedUnion<TFirst, TSecond>>
{
    private readonly InternalTag tag;

    private readonly TFirst first;

    private readonly TSecond second;

    public bool IsInitialized
        =>
        tag != default;

    public bool IsFirst
        =>
        tag is InternalTag.First;

    public bool IsSecond
        =>
        tag is InternalTag.Second;
}
