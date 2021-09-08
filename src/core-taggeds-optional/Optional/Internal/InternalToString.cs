#nullable enable

using static System.FormattableString;

namespace System
{
    internal static class InternalToString<T>
    {
        public static string Present(T value)
            =>
            Invariant($"Present[{typeof(T)}]:{value}");

        public static string OptionalPresent(T value)
            =>
            Invariant($"Optional.Present[{typeof(T)}]:{value}");

        public static string Absent()
            =>
            Invariant($"Absent[{typeof(T)}]:()");

        public static string OptionalAbsent()
            =>
            Invariant($"Optional.Absent[{typeof(T)}]:()");
    }
}
