#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    public static class StringPredicateExtensions
    {
        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
            =>
            string.IsNullOrEmpty(value);

        public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
            =>
            string.IsNullOrWhiteSpace(value);
    }
}
