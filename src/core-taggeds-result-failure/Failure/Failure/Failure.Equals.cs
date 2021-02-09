#nullable enable

namespace System
{
    partial class Failure
    {
        public static bool Equals<TFailureCode>(
            Failure<TFailureCode> failureA,
            Failure<TFailureCode> failureB)
            where TFailureCode : struct
            =>
            Failure<TFailureCode>.Equals(failureA, failureB);
    }
}