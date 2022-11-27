namespace System;

public readonly partial struct TaggedUnion<TFirst, TSecond> : IEquatable<TaggedUnion<TFirst, TSecond>>
{
    private readonly Tag tag;

    private readonly TFirst first;

    private readonly TSecond second;

    public bool IsNone
        =>
        tag is Tag.None;

    public bool IsFirst
        =>
        tag is Tag.First;

    public bool IsSecond
        =>
        tag is Tag.Second;

    // TODO: Consider to remove the property in v3.0 or v4.0
    [Obsolete("This property is obsolete. Consider to test IsNone for false instead.", error: true)]
    public bool IsInitialized
        =>
        tag is not Tag.None;
}
