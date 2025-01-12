using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    private T? InnerOrDefault
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value;
    }
}
