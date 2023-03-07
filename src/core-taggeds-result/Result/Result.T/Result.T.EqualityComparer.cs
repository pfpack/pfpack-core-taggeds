using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    // TODO: Add the tests and open the class
    internal sealed class EqualityComparer : IEqualityComparer<Result<TSuccess, TFailure>>
    {
        private readonly IEqualityComparer<TSuccess> successComparer;

        private readonly IEqualityComparer<TFailure> failureComparer;

        private EqualityComparer(
            IEqualityComparer<TSuccess> successComparer,
            IEqualityComparer<TFailure> failureComparer)
        {
            this.successComparer = successComparer;
            this.failureComparer = failureComparer;
        }

        public static EqualityComparer Create(
            IEqualityComparer<TSuccess>? successComparer,
            IEqualityComparer<TFailure>? failureComparer)
            =>
            new(
                successComparer ?? EqualityComparer<TSuccess>.Default,
                failureComparer ?? EqualityComparer<TFailure>.Default);

        public static EqualityComparer Create(IEqualityComparer<TSuccess>? successComparer)
            =>
            new(
                successComparer ?? EqualityComparer<TSuccess>.Default,
                EqualityComparer<TFailure>.Default);

        public static EqualityComparer Create(IEqualityComparer<TFailure>? failureComparer)
            =>
            new(
                EqualityComparer<TSuccess>.Default,
                failureComparer ?? EqualityComparer<TFailure>.Default);

        public static EqualityComparer Create()
            =>
            new(
                EqualityComparer<TSuccess>.Default,
                EqualityComparer<TFailure>.Default);

        public static EqualityComparer Default
            =>
            InnerDefault.Value;

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

        private static class InnerDefault
        {
            internal static readonly EqualityComparer Value = Create();
        }
    }
}
