#nullable enable

namespace System
{
    partial struct Failure<TFailureCode>
    {
        public static bool Equals(
            Failure<TFailureCode> failureA,
            Failure<TFailureCode> failureB)
            =>
            FailureCodeComparer.Equals(failureA.FailureCode, failureB.FailureCode)
            && FailureMessageComparer.Equals(failureA.FailureMessage, failureB.FailureMessage);

        public bool Equals(
            Failure<TFailureCode> other)
            =>
            Equals(this, other);

        public override bool Equals(
            object? obj)
            =>
            obj is Failure<TFailureCode> other
            && Equals(this, other);
    }
}