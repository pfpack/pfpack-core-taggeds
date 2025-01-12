using System.Collections.Generic;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    // TODO: Add the tests and open the type
    internal sealed partial class EqualityComparer : IEqualityComparer<Result<TSuccess, TFailure>>
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

        private static class InnerDefault
        {
            internal static readonly EqualityComparer Value = Create();
        }
    }
}
