using System.Runtime.CompilerServices;

namespace System;

partial struct Present<T>
{
    public override int GetHashCode()
        =>
        value is not null
            ? HashCode.Combine(EqualityContractHashCode(), EqualityComparer.GetHashCode(value))
            : HashCode.Combine(EqualityContractHashCode());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityContractComparer.GetHashCode(EqualityContract);
}
