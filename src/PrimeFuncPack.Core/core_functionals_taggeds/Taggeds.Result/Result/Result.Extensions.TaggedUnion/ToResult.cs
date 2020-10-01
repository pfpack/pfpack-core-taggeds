#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        public static Result<TSuccess, TFailure> ToResult<TSuccess, TFailure>(this TaggedUnion<TSuccess, TFailure> union)
            where TSuccess : notnull
            where TFailure : notnull, new()
            =>
            union.Fold(
                value => value switch { not null => Result<TSuccess, TFailure>.Success(value), _ => default },
                value => value switch { not null => Result<TSuccess, TFailure>.Failure(value), _ => default });
    }
}
