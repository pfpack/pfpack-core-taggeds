using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ref readonly T InternalOrElseRef(ref readonly Optional<T> optional, ref readonly T other)
        =>
        ref optional.hasValue ? ref optional.value : ref other;
}
