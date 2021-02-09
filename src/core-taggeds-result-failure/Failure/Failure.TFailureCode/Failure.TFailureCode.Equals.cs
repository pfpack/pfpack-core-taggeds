#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct Failure<TFailureCode>
    {
        public static bool Equals(
            Failure<TFailureCode> failureA,
            Failure<TFailureCode> failureB)
            =>
            FailureCodeEqualityComparer.Equals(failureA.FailureCode, failureB.FailureCode)
            && FailureMessageStringComparer.Equals(failureA.FailureMessage, failureB.FailureMessage);

        public bool Equals(
            Failure<TFailureCode> other)
            =>
            Equals(this, other);

        public override bool Equals(
            object? obj)
            =>
            obj is Failure<TFailureCode> other
            && Equals(this, other);

        private static IEqualityComparer<TFailureCode> FailureCodeEqualityComparer
            =>
            EqualityComparer<TFailureCode>.Default;

        private static StringComparer FailureMessageStringComparer
            =>
            StringComparer.Ordinal;
    }
}