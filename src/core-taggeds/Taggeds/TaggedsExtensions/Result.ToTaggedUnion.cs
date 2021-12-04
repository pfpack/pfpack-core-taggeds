namespace System
{
    partial class TaggedsExtensions
    {
        public static TaggedUnion<TSuccess, TFailure> ToTaggedUnion<TSuccess, TFailure>(
            this Result<TSuccess, TFailure> result)
            where TFailure : struct
            =>
            result.Fold<TaggedUnion<TSuccess, TFailure>>(
                value => new(value),
                value => new(value));
    }
}
