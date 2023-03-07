using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public override int GetHashCode()
    {
        if (tag is Tag.First)
        {
            return FirstHashCode();
        }

        if (tag is Tag.Second)
        {
            return SecondHashCode();
        }

        return NoneHashCode();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int FirstHashCode()
        =>
        first is not null
            ? HashCode.Combine(EqualityContractHashCode(), Tag.First, EqualityComparer<TFirst>.Default.GetHashCode(first))
            : HashCode.Combine(EqualityContractHashCode(), Tag.First);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int SecondHashCode()
        =>
        second is not null
            ? HashCode.Combine(EqualityContractHashCode(), Tag.Second, EqualityComparer<TSecond>.Default.GetHashCode(second))
            : HashCode.Combine(EqualityContractHashCode(), Tag.Second);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int NoneHashCode()
        =>
        HashCode.Combine(EqualityContractHashCode());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(TaggedUnion<TFirst, TSecond>));
}
