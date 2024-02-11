namespace System;

partial class TaggedsExtensions
{
    [Obsolete("TaggedUnion and this method are obsolete and will be removed in Taggeds v3.0.", error: false)]
    public static Result<TSuccess, TFailure> ToResult<TSuccess, TFailure>(
        this TaggedUnion<TSuccess, TFailure> union)
        where TFailure : struct
        =>
        union.Fold<Result<TSuccess, TFailure>>(
            success => new(success),
            failure => new(failure));
}
