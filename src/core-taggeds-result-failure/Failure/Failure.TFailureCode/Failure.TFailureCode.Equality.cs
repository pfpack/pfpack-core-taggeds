#nullable enable

namespace System
{
    partial struct Failure<TFailureCode>
    {
        public static bool operator ==(Failure<TFailureCode> failureA, Failure<TFailureCode> failureB)
            =>
            Equals(failureA, failureB);

        public static bool operator !=(Failure<TFailureCode> failureA, Failure<TFailureCode> failureB)
            =>
            Equals(failureA, failureB) is false;
    }
}