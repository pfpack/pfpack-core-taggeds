namespace System;

partial class TaggedsExtensions
{
    [Obsolete("TaggedUnion and this method are obsolete and will be removed in Taggeds v3.0.", error: false)]
    public static TaggedUnion<T, Unit> ToTaggedUnion<T>(this Optional<T> optional)
        =>
        optional.Fold<TaggedUnion<T, Unit>>(
            value => new(value),
            static () => new(default(Unit)));
}
