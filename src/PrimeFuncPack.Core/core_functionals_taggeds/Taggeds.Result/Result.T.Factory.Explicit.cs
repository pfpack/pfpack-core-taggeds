#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static Result<TSuccess, TFailure> Success(TSuccess success)
            =>
            new Result<TSuccess, TFailure>(success: success ?? throw new ArgumentNullException(nameof(success)));

        public static Result<TSuccess, TFailure> Failure(TFailure failure)
            =>
            new Result<TSuccess, TFailure>(failure: failure ?? throw new ArgumentNullException(nameof(failure)));
    }
}
