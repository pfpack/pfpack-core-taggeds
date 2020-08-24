#nullable enable

namespace System
{
    public readonly partial struct Result<TSuccess, TFailure>
        where TSuccess : notnull
        where TFailure : notnull, new()
    {
        private readonly TaggedUnion<TSuccess, TFailure> _union;

        public bool IsSuccess => _union.IsFirst;

        public bool IsFailure => _union.IsSecond;

        private Result(in TSuccess success)
            =>
            _union = UnionSuccess(success);

        private Result(in TFailure failure)
            =>
            _union = UnionFailure(failure);

        private TaggedUnion<TSuccess, TFailure> Union()
            =>
            _union.IsInitialized switch
            {
                true => _union,
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
