using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal int InternalCompareTo(Optional<T> other)
    {
        const int greaterThan = 1;
        const int lessThan = -1;
        const int equalTo = default;

        if (hasValue && other.hasValue)
        {
            return Comparer<T>.Default.Compare(value, other.value) switch // Normalize comparison result
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
