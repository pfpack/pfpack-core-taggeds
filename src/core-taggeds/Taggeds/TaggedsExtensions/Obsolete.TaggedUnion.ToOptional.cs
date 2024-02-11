namespace System;

partial class TaggedsExtensions
{
    [Obsolete("TaggedUnion and this method are obsolete and will be removed in Taggeds v3.0.", error: false)]
    public static Optional<T> ToOptional<T>(this TaggedUnion<T, Unit> union)
        =>
        union.Fold<Optional<T>>(
            value => new(value),
            static _ => default);
}
