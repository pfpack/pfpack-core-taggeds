#nullable enable

namespace System
{
    public static class StringExtensions
    {
        public static string OrEmpty(this string? value)
            =>
            Strings.OrEmpty(value);

        public static string ToStringOrEmpty<T>(this T value)
            =>
            Strings.ToStringOrEmpty(value);
    }
}
