using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    public override int GetHashCode()
        =>
        hasValue ? PresentHashCode() : AbsentHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int PresentHashCode()
        =>
        value is not null
            ? HashCode.Combine(EqualityContractHashCode(), true, EqualityComparer.GetHashCode(value))
            : HashCode.Combine(EqualityContractHashCode(), true);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int AbsentHashCode()
        =>
        HashCode.Combine(EqualityContractHashCode());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityContractComparer.GetHashCode(EqualityContract);
}
