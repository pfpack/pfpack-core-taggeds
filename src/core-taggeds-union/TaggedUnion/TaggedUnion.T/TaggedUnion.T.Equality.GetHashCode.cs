using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public override int GetHashCode()
    {
        if (tag is Tag.First)
        {
            return PresentHashCode(first);
        }

        if (tag is Tag.Second)
        {
            return PresentHashCode(second);
        }

        return NoneHashCode();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int PresentHashCode<TValue>(TValue value)
        =>
        value is not null
            ? HashCode.Combine(EqualityContractHashCode(), tag, EqualityComparer<TValue>.Default.GetHashCode(value))
            : HashCode.Combine(EqualityContractHashCode(), tag);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int NoneHashCode()
        =>
        HashCode.Combine(EqualityContractHashCode());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(TaggedUnion<TFirst, TSecond>));
}
