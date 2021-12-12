using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int InnerCount()
        =>
        hasValue ? 1 : default;
}
