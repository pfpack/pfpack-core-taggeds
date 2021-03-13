#nullable enable

namespace System
{
    partial struct Failure<TFailureCode>
    {
        public override int GetHashCode()
            =>
            HashCode.Combine(
                typeof(Failure<TFailureCode>),
                FailureCodeComparer.GetHashCode(FailureCode),
                FailureMessageComparer.GetHashCode(FailureMessage));
    }
}