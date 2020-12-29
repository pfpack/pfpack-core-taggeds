#nullable enable

namespace System
{
    public static class Strings
    {
        public const string Empty = "";

        public static string GetEmpty() => Empty;

        public static string OrEmpty(string? value)
            =>
            value ?? Empty;

        public static string ToStringOrEmpty<T>(T value)
            =>
            value switch { not null => value.ToString() ?? Empty, _ => Empty };
    }
}
