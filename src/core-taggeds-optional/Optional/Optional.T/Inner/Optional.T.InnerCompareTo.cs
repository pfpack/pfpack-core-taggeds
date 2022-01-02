using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int InnerCompareTo(Optional<T> other)
    {
        const int greaterThan = 1;
        const int lessThan = -1;
        const int equalTo = default;

        if (hasValue != other.hasValue)
        {
            return hasValue ? greaterThan : lessThan;
        }

        if (hasValue)
        {
            return Comparer<T>.Default.Compare(value, other.value) switch
            {
                // Normalize comparison result:
                > equalTo => greaterThan,
                < equalTo => lessThan,
                _ => equalTo
            };
        }

        return equalTo;
    }
}
