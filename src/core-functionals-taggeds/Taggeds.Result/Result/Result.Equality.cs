#nullable enable

namespace System
{
    partial class Result
    {
        public static bool Equals<TSuccess, TFailure>(Result<TSuccess, TFailure> resultA, Result<TSuccess, TFailure> resultB)
            where TSuccess : notnull
            where TFailure : struct
            =>
            Result<TSuccess, TFailure>.Equals(resultA, resultB);
    }
}
