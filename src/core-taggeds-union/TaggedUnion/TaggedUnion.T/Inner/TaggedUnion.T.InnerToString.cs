using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string InnerToString()
        =>
        InnerFold(
            first => InnerToString("First", first),
            second => InnerToString("Second", second),
            () => InnerToString("None", "()"));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToString<TValue>(string tag, TValue value)
        =>
        Invariant($"TaggedUnion<{typeof(TFirst).Name}, {typeof(TSecond).Name}>:{tag}:{value}");
}
