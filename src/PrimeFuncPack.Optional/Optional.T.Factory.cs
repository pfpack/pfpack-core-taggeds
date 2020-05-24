#nullable enable

using System;

namespace PrimeFuncPack
{
    partial struct Optional<T>
    {
        public static readonly Optional<T> Absent;

        private Optional(in T value)
            =>
            box = value;

        public static Optional<T> PresentEvenIfNull(in T value)
            =>
            new Optional<T>(value);

        public static Optional<T> PresentOrThrowIfNull(in T value) => value switch
        {
            null => throw new ArgumentNullException(nameof(value)),
            var present => new Optional<T>(present)
        };

        public static Optional<T> PresentOrAbsentIfNull(in T value) => value switch
        {
            null => Absent,
            var present => new Optional<T>(present)
        };
    }
}
