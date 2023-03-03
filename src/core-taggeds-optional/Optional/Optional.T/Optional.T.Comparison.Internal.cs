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
            return comparer.Compare(value, other.value) switch
            {
                > ComparisonResult.EqualTo => ComparisonResult.GreaterThan,
                < ComparisonResult.EqualTo => ComparisonResult.LessThan,
                _ => ComparisonResult.EqualTo
            };
        }

        return ComparisonResult.EqualTo;
    }
}
