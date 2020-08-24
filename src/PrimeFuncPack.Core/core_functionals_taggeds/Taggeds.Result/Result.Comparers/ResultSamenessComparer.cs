#nullable enable

using System.Collections.Generic;

namespace System
{
    public sealed class ResultSamenessComparer<TSuccess, TFailure> : IEqualityComparer<Result<TSuccess, TFailure>>
        where TSuccess : notnull
        where TFailure : notnull, new()
    {
        public bool Equals(Result<TSuccess, TFailure> x, Result<TSuccess, TFailure> y)
            =>
            Result<TSuccess, TFailure>.Same(x, y);

        public int GetHashCode(Result<TSuccess, TFailure> obj)
            =>
            obj.GetSamenessHashCode();

        public static ResultSamenessComparer<TSuccess, TFailure> Default => ResultSamenessComparerDefault<TSuccess, TFailure>.Value;
    }

    internal static class ResultSamenessComparerDefault<TSuccess, TFailure>
        where TSuccess : notnull
        where TFailure : notnull, new()
    {
        public static readonly ResultSamenessComparer<TSuccess, TFailure> Value = new ResultSamenessComparer<TSuccess, TFailure>();
    }
}
