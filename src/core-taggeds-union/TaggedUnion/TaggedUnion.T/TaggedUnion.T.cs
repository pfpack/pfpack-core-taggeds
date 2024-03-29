﻿namespace System;

[Obsolete("TaggedUnion is obsolete and will be removed in Taggeds v3.0.", error: false)]
public readonly partial struct TaggedUnion<TFirst, TSecond> : IEquatable<TaggedUnion<TFirst, TSecond>>
{
    private readonly Tag tag;

    private readonly TFirst first;

    private readonly TSecond second;

    public bool IsNone
        =>
        tag is Tag.None;

    public bool IsNotNone
        =>
        tag is not Tag.None;

    public bool IsFirst
        =>
        tag is Tag.First;

    public bool IsSecond
        =>
        tag is Tag.Second;

    // TODO: Remove the property in v3.0
    [Obsolete("This property is obsolete. Call IsNotNone instead.", error: true)]
    public bool IsInitialized
        =>
        tag is not Tag.None;
}
