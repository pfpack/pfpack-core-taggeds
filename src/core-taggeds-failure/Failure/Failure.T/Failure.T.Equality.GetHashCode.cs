namespace System;

partial struct Failure<TFailureCode>
{
    public override int GetHashCode()
        =>
        HashCode.Combine(
            EqualityContract,
            FailureCodeComparer.GetHashCode(FailureCode),
            FailureMessageComparer.GetHashCode(FailureMessage));
}
