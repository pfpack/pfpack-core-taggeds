using System.Collections.Generic;
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
            ? HashCode.Combine(EqualityContractHashCode(), true, SuccessComparer.GetHashCode(success))
            : HashCode.Combine(EqualityContractHashCode(), true);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int FailureHashCode()
        =>
        HashCode.Combine(EqualityContractHashCode(), false, FailureComparer.GetHashCode(failure));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(Result<TSuccess, TFailure>));
}
