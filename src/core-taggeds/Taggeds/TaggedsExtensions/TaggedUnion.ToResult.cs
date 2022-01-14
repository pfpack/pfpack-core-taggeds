namespace System;

partial class TaggedsExtensions
{
    public static Result<TSuccess, TFailure> ToResult<TSuccess, TFailure>(
        this TaggedUnion<TSuccess, TFailure> union)
        where TFailure : struct
        =>
        union.Fold<Result<TSuccess, TFailure>>(
            success => new(success),
            failure => new(failure));
}
