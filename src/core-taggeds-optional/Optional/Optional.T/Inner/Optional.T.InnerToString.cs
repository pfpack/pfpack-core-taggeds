using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string InnerToString()
        =>
        hasValue
        ? InnerToString("Present", value)
        : InnerToString("Absent", "()");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToString<TValue>(string tag, TValue value)
        =>
        Invariant($"Optional<{typeof(T).Name}>:{tag}:{value}");
}
