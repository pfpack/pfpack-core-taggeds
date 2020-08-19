#nullable enable

namespace System
{
    public readonly partial struct Result<TSuccess, TFailure>
        where TFailure : notnull, new()
    {
        private readonly TaggedUnion<TSuccess, TFailure> _union;

        private TaggedUnion<TSuccess, TFailure> Union => _union.IsInitialized switch
        {
            true => _union,
            _ => TaggedUnion<TSuccess, TFailure>.CreateSecond(new TFailure())
        };

        private Result(in TSuccess success)
            =>
            _union = TaggedUnion<TSuccess, TFailure>.CreateFirst(success);

        private Result(in TFailure failure)
            =>
            _union = TaggedUnion<TSuccess, TFailure>.CreateSecond(failure);
    }
}
