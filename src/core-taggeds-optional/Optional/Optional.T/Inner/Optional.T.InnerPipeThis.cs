using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerPipeThis(Optional<T> optional) => optional;
}
