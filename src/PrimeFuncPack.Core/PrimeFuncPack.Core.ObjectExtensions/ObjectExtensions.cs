#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull<T>([NotNullWhen(true)][MaybeNullWhen(false)] this T value)
            =>
            value is not null;

        public static bool IsNull<T>([NotNullWhen(false)][MaybeNullWhen(true)] this T value)
            =>
            value is null;

        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
            =>
            string.IsNullOrEmpty(value);

        public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
            =>
            string.IsNullOrWhiteSpace(value);

        public static string OrEmpty(this string? value)
            =>
            value ?? string.Empty;
    }
}
