#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    public static class ObjectPredicateExtensions
    {
        public static bool IsNotNull<T>([NotNullWhen(true)][MaybeNullWhen(false)] this T value)
            =>
            value is not null;

        public static bool IsNull<T>([NotNullWhen(false)][MaybeNullWhen(true)] this T value)
            =>
            value is null;
    }
}
