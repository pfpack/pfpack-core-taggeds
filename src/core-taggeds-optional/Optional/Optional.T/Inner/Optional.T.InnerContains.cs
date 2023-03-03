using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool InnerContains(T value)
        =>
        hasValue && EqualityComparer<T>.Default.Equals(this.value, value);
}
