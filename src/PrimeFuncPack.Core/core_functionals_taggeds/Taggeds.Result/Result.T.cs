#nullable enable

namespace System
{
    public readonly partial struct Result<TSuccess, TFailure> :
        IEquatable<Result<TSuccess, TFailure>>,
        ISamenessEquatable<Result<TSuccess, TFailure>>
        where TSuccess : notnull
        where TFailure : notnull, new()
    {
        private readonly TaggedUnion<TSuccess, TFailure> unionRaw;

        private TaggedUnion<TSuccess, TFailure> Union
            =>
            unionRaw.Or(() => UnionFailure(new TFailure()));

        public bool IsSuccess
            =>
            unionRaw.IsFirst;

        public bool IsFailure
            =>
            IsSuccess is false;

        private Result(in TSuccess success)
            =>
            unionRaw = UnionSuccess(success);

        private Result(in TFailure failure)
            =>
            unionRaw = UnionFailure(failure);
    }
}
