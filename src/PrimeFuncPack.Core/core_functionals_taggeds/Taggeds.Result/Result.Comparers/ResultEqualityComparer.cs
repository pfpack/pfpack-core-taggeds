#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class ResultEqualityComparer<TSuccess, TFailure> : IEqualityComparer<Result<TSuccess, TFailure>>
        where TSuccess : notnull
        where TFailure : notnull, new()
    {
        public bool Equals(Result<TSuccess, TFailure> x, Result<TSuccess, TFailure> y)
            =>
            Result<TSuccess, TFailure>.Equals(x, y);

        public int GetHashCode(Result<TSuccess, TFailure> obj)
            =>
            obj.GetHashCode();

        public static ResultEqualityComparer<TSuccess, TFailure> Default => ResultEqualityComparerDefault<TSuccess, TFailure>.Value;
    }

    internal static class ResultEqualityComparerDefault<TSuccess, TFailure>
        where TSuccess : notnull
        where TFailure : notnull, new()
    {
        public static readonly ResultEqualityComparer<TSuccess, TFailure> Value = new ResultEqualityComparer<TSuccess, TFailure>();
    }
}
