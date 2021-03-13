#nullable enable

namespace System
{
    public readonly partial struct Result<TSuccess, TFailure> : IEquatable<Result<TSuccess, TFailure>>
        where TFailure : struct
    {
        private readonly TaggedUnion<TSuccess, TFailure> union;

        private readonly TaggedUnion<TSuccess, TFailure> Union
            =>
            union.IsInitialized
                ? union
                : new(default(TFailure));

        public bool IsSuccess => Union.IsFirst;

        public bool IsFailure => Union.IsSecond;
    }
}
