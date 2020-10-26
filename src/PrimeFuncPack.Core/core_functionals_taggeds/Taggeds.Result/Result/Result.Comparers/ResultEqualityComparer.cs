#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class ResultEqualityComparer<TSuccess, TFailure> : IEqualityComparer<Result<TSuccess, TFailure>>
        where TSuccess : notnull
        where TFailure : struct
    {
        public bool Equals(Result<TSuccess, TFailure> resultA, Result<TSuccess, TFailure> resultB)
            =>
            Result<TSuccess, TFailure>.Equals(resultA, resultB);

        public int GetHashCode(Result<TSuccess, TFailure> result)
            =>
            result.GetHashCode();

        public static ResultEqualityComparer<TSuccess, TFailure> Default => ResultEqualityComparerDefault<TSuccess, TFailure>.Value;
    }

    internal static class ResultEqualityComparerDefault<TSuccess, TFailure>
        where TSuccess : notnull
        where TFailure : struct
    {
        public static readonly ResultEqualityComparer<TSuccess, TFailure> Value = new ResultEqualityComparer<TSuccess, TFailure>();
    }
}
