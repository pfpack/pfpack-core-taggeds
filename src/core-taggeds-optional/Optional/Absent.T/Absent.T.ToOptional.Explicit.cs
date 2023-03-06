using System.Runtime.CompilerServices;

namespace System;

partial struct Absent<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Optional<T> ToOptional() => default;
}
