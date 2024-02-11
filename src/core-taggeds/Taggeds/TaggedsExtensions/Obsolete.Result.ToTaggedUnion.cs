namespace System;

partial class TaggedsExtensions
{
    [Obsolete("TaggedUnion and this method are obsolete and will be removed in Taggeds v3.0.", error: false)]
    public static TaggedUnion<TSuccess, TFailure> ToTaggedUnion<TSuccess, TFailure>(
        this Result<TSuccess, TFailure> result)
        where TFailure : struct
        =>
        result.Fold<TaggedUnion<TSuccess, TFailure>>(
            success => new(success),
            failure => new(failure));
}
