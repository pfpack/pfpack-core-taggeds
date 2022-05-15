using System;
using System.Runtime.CompilerServices;

namespace PrimeFuncPack.Core;

partial struct SuccessBuilder<TSuccess>
{
    public override int GetHashCode()
        =>
        success is not null
            ? HashCode.Combine(EqualityContractHashCode(), SuccessComparer.GetHashCode(success))
            : HashCode.Combine(EqualityContractHashCode());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityContractComparer.GetHashCode(EqualityContract);
}
