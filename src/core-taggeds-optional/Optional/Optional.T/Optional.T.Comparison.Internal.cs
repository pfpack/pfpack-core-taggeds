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
            return hasValue
                ? ComparisonResult.GreaterThan
                : ComparisonResult.LessThan;
        }

        if (hasValue)
        {
            var result = comparer.Compare(value, other.value);
            return ComparisonResult.Normalize(result);
        }

        return ComparisonResult.EqualTo;
    }
}
