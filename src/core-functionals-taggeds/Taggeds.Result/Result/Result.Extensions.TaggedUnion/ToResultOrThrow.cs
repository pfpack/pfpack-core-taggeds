#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        public static Result<TSuccess, TFailure> ToResultOrThrow<TSuccess, TFailure>(this TaggedUnion<TSuccess, TFailure> union)
            where TSuccess : notnull
            where TFailure : struct
            =>
            union.Fold<Result<TSuccess, TFailure>>(
                static value => value ?? throw CreateSuccessNullException(nameof(union)),
                static value => value);
    }
}
