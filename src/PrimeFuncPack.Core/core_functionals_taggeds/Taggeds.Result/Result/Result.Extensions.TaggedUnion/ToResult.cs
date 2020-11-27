#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        public static Result<TSuccess, TFailure> ToResult<TSuccess, TFailure>(this TaggedUnion<TSuccess, TFailure> union)
            where TSuccess : notnull
            where TFailure : notnull, new()
            =>
            union.Fold<Result<TSuccess, TFailure>>(
                value => value switch { not null => new(value), _ => default },
                value => value switch { not null => new(value), _ => default });
    }
}
