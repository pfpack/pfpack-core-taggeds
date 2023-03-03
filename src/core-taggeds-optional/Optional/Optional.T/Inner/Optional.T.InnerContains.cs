using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool InnerContains(T value)
        =>
        hasValue && ValueEqualityComparer.Equals(this.value, value);
}
