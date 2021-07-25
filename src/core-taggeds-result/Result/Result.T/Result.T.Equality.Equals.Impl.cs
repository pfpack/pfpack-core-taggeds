#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public bool Equals(Result<TSuccess, TFailure> other)
            =>
            (isSuccess == other.isSuccess) &&
            (isSuccess
                ? SuccessComparer.Equals(success, other.success)
                : FailureComparer.Equals(failure, other.failure));
    }
}
