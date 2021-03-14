#nullable enable

namespace System
{
    partial struct Failure<TFailureCode>
    {
        public bool Equals(
            Failure<TFailureCode> other)
            =>
            FailureCodeComparer.Equals(FailureCode, other.FailureCode)
            && FailureMessageComparer.Equals(FailureMessage, other.FailureMessage);
    }
}