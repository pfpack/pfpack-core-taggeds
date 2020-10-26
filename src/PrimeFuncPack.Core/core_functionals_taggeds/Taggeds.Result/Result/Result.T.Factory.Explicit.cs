#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static Result<TSuccess, TFailure> Success(TSuccess success)
            =>
            new Result<TSuccess, TFailure>(success ?? throw new ArgumentNullException(nameof(success)));

        public static Result<TSuccess, TFailure> Failure(TFailure failure)
            =>
            new Result<TSuccess, TFailure>(failure);
    }
}
