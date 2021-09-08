#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class InternalToString<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Present(T value)
            =>
            InnerPresent("Present", value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string OptionalPresent(T value)
            =>
            InnerPresent("Optional.Present", value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Absent()
            =>
            InnerAbsent("Absent");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string OptionalAbsent()
            =>
            InnerAbsent("Optional.Absent");
    }
}
