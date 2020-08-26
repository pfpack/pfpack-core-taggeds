#nullable enable

namespace System
{
    public readonly partial struct Result<TSuccess, TFailure> :
        IEquatable<Result<TSuccess, TFailure>>,
        ISamenessEquatable<Result<TSuccess, TFailure>>
        where TSuccess : notnull
        where TFailure : notnull, new()
    {
        private const string CategorySuccess = "Success";

        private const string CategoryFailure = "Failure";

        private readonly TaggedUnion<TSuccess, TFailure> union;

        public bool IsSuccess => union.IsFirst;

        public bool IsFailure => union.IsFirst is false;

        private Result(in TSuccess success)
            =>
            union = ResultUnion<TSuccess, TFailure>.Success(success);

        private Result(in TFailure failure)
            =>
            union = ResultUnion<TSuccess, TFailure>.Failure(failure);
    }
}
