namespace System;

partial class Result
{
    public static bool Equals<TSuccess, TFailure>(
        Result<TSuccess, TFailure> left, Result<TSuccess, TFailure> right)
        where TFailure : struct
        =>
        left.Equals(right);
}
