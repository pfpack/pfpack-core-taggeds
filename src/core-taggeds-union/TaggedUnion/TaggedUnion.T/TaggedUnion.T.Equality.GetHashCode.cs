using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public override int GetHashCode()
    {
        if (tag is InternalTag.First)
        {
            return FirstHashCode();
        }

        if (tag is InternalTag.Second)
        {
            return SecondHashCode();
        }

        return NoneHashCode();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int FirstHashCode()
        =>
        first is not null
            ? HashCode.Combine(EqualityContractHashCode(), InternalTag.First, FirstComparer.GetHashCode(first))
            : HashCode.Combine(EqualityContractHashCode(), InternalTag.First);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int SecondHashCode()
        =>
        second is not null
            ? HashCode.Combine(EqualityContractHashCode(), InternalTag.Second, SecondComparer.GetHashCode(second))
            : HashCode.Combine(EqualityContractHashCode(), InternalTag.Second);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int NoneHashCode()
        =>
        HashCode.Combine(EqualityContractHashCode());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityContractComparer.GetHashCode(EqualityContract);
}
