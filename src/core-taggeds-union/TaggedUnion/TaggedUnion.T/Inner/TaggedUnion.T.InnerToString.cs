using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string InnerToString()
        =>
        InnerFold(InnerToStringFirst, InnerToStringSecond, InnerToStringNone);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringFirst(TFirst first)
        =>
        Invariant($"{InnerToStringPrefix()}:First:{first}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringSecond(TSecond second)
        =>
        Invariant($"{InnerToStringPrefix()}:Second:{second}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringNone()
        =>
        Invariant($"{InnerToStringPrefix()}:None:()");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringPrefix()
        =>
        Invariant($"TaggedUnion[{typeof(TFirst)},{typeof(TSecond)}]");
}
