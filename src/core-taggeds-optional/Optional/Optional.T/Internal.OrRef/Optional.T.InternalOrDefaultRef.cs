using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ref readonly T? InternalOrDefaultRef(ref readonly Optional<T> optional)
        =>
        ref optional.value!;
}
