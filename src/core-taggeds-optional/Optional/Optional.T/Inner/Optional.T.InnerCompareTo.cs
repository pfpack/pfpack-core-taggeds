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

        if (hasValue && other.hasValue)
        {
            // Normalize comparison result
            return Comparer<T>.Default.Compare(value, other.value) switch
            {
                > equalTo => greaterThan,
                < equalTo => lessThan,
                _ => equalTo
            };
        }

        if (hasValue)
        {
            return greaterThan;
        }

        if (other.hasValue)
        {
            return lessThan;
        }

        return equalTo;
    }
}
