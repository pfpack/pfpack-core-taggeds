#nullable enable

namespace System
{
    partial struct Failure<TFailureCode>
    {
        public override int GetHashCode()
            =>
            HashCode.Combine(
                typeof(Failure<TFailureCode>),
                FailureCode.GetHashCode(),
                FailureMessage.GetHashCode());
    }
}