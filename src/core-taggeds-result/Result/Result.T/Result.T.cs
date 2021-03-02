#nullable enable

namespace System
{
    public readonly partial struct Result<TSuccess, TFailure> : IEquatable<Result<TSuccess, TFailure>>
        where TFailure : struct
    {
        private readonly TaggedUnion<TSuccess, TFailure> unionRaw;

        private readonly TaggedUnion<TSuccess, TFailure> Union
            =>
            unionRaw.IsInitialized switch
            {
                true => unionRaw,
                _ => new(default(TFailure))
            };

        public bool IsSuccess => Union.IsFirst;

        public bool IsFailure => Union.IsSecond;
    }
}
