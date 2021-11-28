using System.Runtime.CompilerServices;

namespace System;

partial class InternalToString<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Present(T value)
        =>
        InnerFormat<T>.Invoke("Present", value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string OptionalPresent(T value)
        =>
        InnerFormat<T>.Invoke("Optional.Present", value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Absent()
        =>
        InnerFormat<string>.Invoke("Absent", InnerConsts.Absent);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string OptionalAbsent()
        =>
        InnerFormat<string>.Invoke("Optional.Absent", InnerConsts.Absent);
}
