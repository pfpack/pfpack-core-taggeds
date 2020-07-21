#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial struct Optional<T>
    {
        public static readonly Optional<T> Absent;

        public static Optional<T> Present(in T value)
            =>
            new Optional<T>(value);

        public static Optional<T> PresentOrThrow([DisallowNull] in T value)
            =>
            new Optional<T>(value ?? throw new ArgumentNullException(nameof(value)));

        public static Optional<T> PresentOrElse(in T value) => value switch
        {
            null => default,
            var present => new Optional<T>(present)
        };

        private Optional(in T value)
            =>
            box = value;
    }
}
