namespace System;

partial struct Result<TSuccess, TFailure>
{
    public bool Equals(Result<TSuccess, TFailure> other)
    {
        if (isSuccess != other.isSuccess)
        {
            return false;
        }

        return isSuccess
            ? SuccessComparer.Equals(success, other.success)
            : FailureComparer.Equals(failure, other.failure);
    }
}
