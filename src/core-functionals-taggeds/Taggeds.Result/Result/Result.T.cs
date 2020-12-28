#nullable enable

namespace System
{
    public readonly partial struct Result<TSuccess, TFailure> : IEquatable<Result<TSuccess, TFailure>>
        where TSuccess : notnull
        where TFailure : struct
    {
        private const string CategorySuccess = "Success";

        private const string CategoryFailure = "Failure";

        private readonly TaggedUnion<TSuccess, TFailure> unionRaw;

        private readonly TaggedUnion<TSuccess, TFailure> Union
        {
            get
            {
                if (unionRaw.IsInitialized)
                {
                    return unionRaw;
                }

                return new(default(TFailure));
            }
        }

        public bool IsSuccess => Union.IsFirst;

        public bool IsFailure => Union.IsSecond;
    }
}
