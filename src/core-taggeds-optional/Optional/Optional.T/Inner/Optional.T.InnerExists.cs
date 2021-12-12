using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool InnerExists(Func<T, bool> predicate)
        =>
        hasValue && predicate.Invoke(value);
}
