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

        if (isSuccess)
        {
            return EqualityComparer<TSuccess>.Default.Equals(success, other.success);
        }

        return EqualityComparer<TFailure>.Default.Equals(failure, other.failure);
    }
}
