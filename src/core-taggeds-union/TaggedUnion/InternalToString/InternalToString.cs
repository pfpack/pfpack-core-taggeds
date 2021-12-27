using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

internal static partial class InternalToString<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TaggedUnionFirst(TFirst value)
        =>
        Invariant($"TaggedUnion[{typeof(TFirst)},{typeof(TSecond)}].First:{value}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TaggedUnionSecond(TSecond value)
        =>
        Invariant($"TaggedUnion[{typeof(TFirst)},{typeof(TSecond)}].Second:{value}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TaggedUnionNone()
        =>
        Invariant($"TaggedUnion[{typeof(TFirst)},{typeof(TSecond)}].None:()");
}
