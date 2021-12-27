namespace System;

public readonly partial struct TaggedUnion<TFirst, TSecond> : IEquatable<TaggedUnion<TFirst, TSecond>>
{
    private readonly InternalTag tag;

    private readonly TFirst first;

    private readonly TSecond second;

    // TODO: Consider to remove the property in v3.0 or v4.0
    [Obsolete("This property is obsolete. Consider to test IsNone for false instead.", error: true)]
    public bool IsInitialized
        =>
        tag is not InternalTag.None;

    public bool IsNone
        =>
        tag is InternalTag.None;

    public bool IsFirst
        =>
        tag is InternalTag.First;

    public bool IsSecond
        =>
        tag is InternalTag.Second;
}
