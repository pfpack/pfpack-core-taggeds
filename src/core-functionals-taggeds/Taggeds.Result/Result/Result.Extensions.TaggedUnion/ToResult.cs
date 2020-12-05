#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        [Obsolete(ObsoleteMessages.ToResult_ReservedForFutureUse, error: true)]
        public static Result<TSuccess, TFailure> ToResult<TSuccess, TFailure>(this TaggedUnion<TSuccess, TFailure> union)
            where TSuccess : notnull
            where TFailure : struct
            =>
            union.Fold<Result<TSuccess, TFailure>>(
                static value => value,
                static value => value);
    }
}
