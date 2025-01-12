using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal int InternalCompareTo(Optional<T> other, IComparer<T> comparer)
    {
        if (hasValue != other.hasValue)
        {
            return hasValue ? ComparisonResult.GreaterThan : ComparisonResult.LessThan;
        }

        if (hasValue)
        {
            return ComparisonResult.Normalize(comparer.Compare(value, other.value));
        }

        return ComparisonResult.EqualTo;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal int InternalCompareTo(T other, Comparer<T> comparer)
    {
        if (hasValue)
        {
            return ComparisonResult.Normalize(comparer.Compare(value, other));
        }

        return ComparisonResult.LessThan;
    }
}
