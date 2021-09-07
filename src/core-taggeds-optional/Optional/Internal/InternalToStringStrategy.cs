#nullable enable

using static System.FormattableString;

namespace System
{
    internal static class InternalToStringStrategy<T>
    {
        public static string Present(T value)
            =>
            Invariant($"A present value of type {typeof(T)}: {value}");

        public static string Absent()
            =>
            Invariant($"The absent value of type {typeof(T)}: ()");
    }
}
