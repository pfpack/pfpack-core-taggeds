using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string InnerToString()
        =>
        InnerFold(InnerToStringPresent, InnerToStringAbsent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringPresent(T value)
        =>
        Invariant($"{InnerToStringPrefix()}:Present:{value}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringAbsent()
        =>
        Invariant($"{InnerToStringPrefix()}:Absent:()");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringPrefix()
        =>
        Invariant($"Optional[{typeof(T)}]");
}
