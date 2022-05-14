namespace System;

partial struct Failure<TFailureCode>
{
    public override int GetHashCode()
        =>
        HashCode.Combine(
            EqualityContractComparer.GetHashCode(EqualityContract),
            FailureCodeComparer.GetHashCode(FailureCode),
            FailureMessageComparer.GetHashCode(FailureMessage));
}
