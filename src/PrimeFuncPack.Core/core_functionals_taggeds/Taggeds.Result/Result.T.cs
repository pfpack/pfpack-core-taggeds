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
            _union = CreateSuccess(success);

        private Result(in TFailure failure)
            =>
            _union = CreateFailure(failure);

        private TaggedUnion<TSuccess, TFailure> Union()
            =>
            _union.IsInitialized switch
            {
                true => _union,
                _ => CreateFailure(new TFailure())
            };

        private static TaggedUnion<TSuccess, TFailure> CreateSuccess(in TSuccess success)
            =>
            TaggedUnion<TSuccess, TFailure>.CreateFirst(success);

        private static TaggedUnion<TSuccess, TFailure> CreateFailure(in TFailure failure)
            =>
            TaggedUnion<TSuccess, TFailure>.CreateSecond(failure);
    }
}
