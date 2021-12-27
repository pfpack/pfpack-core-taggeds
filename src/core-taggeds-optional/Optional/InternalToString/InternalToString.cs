using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

internal static partial class InternalToString<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Present(T value)
        =>
        Invariant($"Present[{typeof(T)}]:{value}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Absent()
        =>
        Invariant($"Absent[{typeof(T)}]:()");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string OptionalPresent(T value)
        =>
        Invariant($"Optional[{typeof(T)}].Present:{value}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string OptionalAbsent()
        =>
        Invariant($"Optional[{typeof(T)}].Absent:()");
}
