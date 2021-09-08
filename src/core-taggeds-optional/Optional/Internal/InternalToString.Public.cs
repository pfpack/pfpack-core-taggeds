#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class InternalToString<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Present(T value)
            =>
            InnerFormatter<T>.Invoke("Present", value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string OptionalPresent(T value)
            =>
            InnerFormatter<T>.Invoke("Optional.Present", value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Absent()
            =>
            InnerFormatter<string>.Invoke("Absent", InnerConsts.Absent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string OptionalAbsent()
            =>
            InnerFormatter<string>.Invoke("Optional.Absent", InnerConsts.Absent);
    }
}
