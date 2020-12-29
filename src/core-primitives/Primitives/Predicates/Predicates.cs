#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    public static class Predicates
    {
        public static bool IsNotNull<T>([NotNullWhen(true)][MaybeNullWhen(false)] T value)
            =>
            value is not null;

        public static bool IsNull<T>([NotNullWhen(false)][MaybeNullWhen(true)] T value)
            =>
            value is null;

        public static bool IsNullOrEmpty([NotNullWhen(false)] string? value)
            =>
            string.IsNullOrEmpty(value);

        public static bool IsNullOrWhiteSpace([NotNullWhen(false)] string? value)
            =>
            string.IsNullOrWhiteSpace(value);
    }
}
