using System.Runtime.CompilerServices;

namespace System;

internal static partial class InternalToString<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Present(T value)
        =>
        InnerFormat<T>.Invoke(InnerPrefix.Present, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Absent()
        =>
        InnerFormat<string>.Invoke(InnerPrefix.Absent, InnerAbsent.ValueString);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string OptionalPresent(T value)
        =>
        InnerFormat<T>.Invoke(InnerPrefix.OptionalPresent, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string OptionalAbsent()
        =>
        InnerFormat<string>.Invoke(InnerPrefix.OptionalAbsent, InnerAbsent.ValueString);
}
