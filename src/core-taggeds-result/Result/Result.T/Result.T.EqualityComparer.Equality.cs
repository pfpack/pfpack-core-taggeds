using System.Runtime.CompilerServices;

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

            return x.isSuccess
                ? successComparer.Equals(x.success, y.success)
                : failureComparer.Equals(x.failure, y.failure);
        }

        public int GetHashCode(Result<TSuccess, TFailure> obj)
            =>
            obj.isSuccess ? SuccessHashCode(obj.success) : FailureHashCode(obj.failure);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int SuccessHashCode(TSuccess success)
            =>
            success is not null
                ? HashCode.Combine(true, successComparer.GetHashCode(success))
                : HashCode.Combine(true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int FailureHashCode(TFailure failure)
            =>
            HashCode.Combine(false, failureComparer.GetHashCode(failure));
    }
}
