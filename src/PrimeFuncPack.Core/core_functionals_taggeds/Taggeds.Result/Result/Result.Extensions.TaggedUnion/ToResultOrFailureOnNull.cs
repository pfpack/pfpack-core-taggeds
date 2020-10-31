#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        public static Result<TSuccess, TFailure> ToResultOrFailureOnNull<TSuccess, TFailure>(
            this TaggedUnion<TSuccess, TFailure> union)
            where TSuccess : notnull
            where TFailure : struct
            =>
            union.Fold(
                value => value switch
                {
                    not null => Result<TSuccess, TFailure>.Success(value),
                    _ => default
                },
                Result<TSuccess, TFailure>.Failure);
    }
}
