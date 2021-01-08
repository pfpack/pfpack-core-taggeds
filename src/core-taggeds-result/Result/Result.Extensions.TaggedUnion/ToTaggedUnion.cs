#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        public static TaggedUnion<TSuccess, TFailure> ToTaggedUnion<TSuccess, TFailure>(
            this Result<TSuccess, TFailure> result)
            where TFailure : struct
            =>
            result.Fold<TaggedUnion<TSuccess, TFailure>>(
                static value => new(value),
                static value => new(value));
    }
}
