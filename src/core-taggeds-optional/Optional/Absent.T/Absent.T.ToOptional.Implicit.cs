#pragma warning disable IDE0060 // Remove unused parameter

using System.Runtime.CompilerServices;

namespace System;

partial struct Absent<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Optional<T>(Absent<T> absent) => default;
}
