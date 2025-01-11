using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private T? InnerOrDefault()
        =>
        value;
}
