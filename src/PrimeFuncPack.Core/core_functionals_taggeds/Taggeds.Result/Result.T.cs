#nullable enable

namespace System
{
    public readonly partial struct Result<TSuccess, TFailure>
        where TSuccess : notnull
        where TFailure : notnull, new()
    {
        private readonly TaggedUnion<TSuccess, TFailure> union;

        public bool IsSuccess => union.IsFirst;

        public bool IsFailure => union.IsSecond;

        private Result(in TSuccess success)
            =>
            union = UnionSuccess(success);

        private Result(in TFailure failure)
            =>
            union = UnionFailure(failure);

        private TaggedUnion<TSuccess, TFailure> Union()
            =>
            union.IsInitialized switch
            {
                true => union,
                _ => UnionFailure(new TFailure())
            };

        private static TaggedUnion<TSuccess, TFailure> UnionSuccess(in TSuccess success)
            =>
            TaggedUnion<TSuccess, TFailure>.First(success);

        private static TaggedUnion<TSuccess, TFailure> UnionFailure(in TFailure failure)
            =>
            TaggedUnion<TSuccess, TFailure>.Second(failure);
    }
}
