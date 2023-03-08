using System.Collections.Generic;

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
            ? EqualityComparer<TSuccess>.Default.Equals(success, other.success)
            : EqualityComparer<TFailure>.Default.Equals(failure, other.failure);
    }
}
