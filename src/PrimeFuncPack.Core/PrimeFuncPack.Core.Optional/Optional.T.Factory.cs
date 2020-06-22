#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial struct Optional<T>
    {
        public static readonly Optional<T> Absent;

        private Optional(in T value)
            =>
            box = value;

        public static Optional<T> Present(in T value)
            =>
            new Optional<T>(value);

        public static Optional<T> PresentOrThrow([DisallowNull] in T value) => value switch
        {
            null
            =>
            throw new ArgumentNullException(nameof(value)),

            var present
            =>
            new Optional<T>(present)
        };

        public static Optional<T> PresentOrAbsent(in T value) => value switch
        {
            null
            =>
            default,

            var present
            =>
            new Optional<T>(present)
        };
    }
}
