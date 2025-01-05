using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    public override int GetHashCode()
    {
        if (hasValue)
        {
            return value is not null
                ? HashCode.Combine(EqualityContractHashCode(), true, EqualityComparer<T>.Default.GetHashCode(value))
                : HashCode.Combine(EqualityContractHashCode(), true);
        }

        return HashCode.Combine(EqualityContractHashCode());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(Optional<T>));
}
