namespace System;

partial struct Result<TSuccess, TFailure>
{
    partial class EqualityComparer
    {
        public bool Equals(Result<TSuccess, TFailure> x, Result<TSuccess, TFailure> y)
        {
            if (x.isSuccess != y.isSuccess)
            {
                return false;
            }

            if (x.isSuccess)
            {
                return successComparer.Equals(x.success, y.success);
            }

            return failureComparer.Equals(x.failure, y.failure);
        }

        public int GetHashCode(Result<TSuccess, TFailure> obj)
        {
            if (obj.isSuccess)
            {
                return obj.success is not null
                    ? HashCode.Combine(true, successComparer.GetHashCode(obj.success))
                    : HashCode.Combine(true);
            }

            return HashCode.Combine(false, failureComparer.GetHashCode(obj.failure));
        }
    }
}
