using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public override int GetHashCode()
        =>
        isSuccess ? SuccessHashCode() : FailureHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int SuccessHashCode()
        =>
        success is not null
            ? HashCode.Combine(EqualityContract, true, SuccessComparer.GetHashCode(success))
            : HashCode.Combine(EqualityContract, true);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int FailureHashCode()
        =>
        HashCode.Combine(EqualityContract, false, FailureComparer.GetHashCode(failure));
}
