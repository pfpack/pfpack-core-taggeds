#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Optional
    {
        public static Optional<T> Present<T>(in T value)
            =>
            Optional<T>.Present(value);

        public static Optional<T> PresentOrThrow<T>([DisallowNull] in T value)
            =>
            Optional<T>.Present(value ?? throw new ArgumentNullException(nameof(value)));

        public static Optional<T> PresentOrThrow<T>([DisallowNull] in T? value) where T : struct
            =>
            PresentOrThrow<T?>(value).MapToNotNullOrThrow();

        public static Optional<T> PresentOrElse<T>([DisallowNull] in T value) => value switch
        {
            null => default,
            var present => Optional<T>.Present(present)
        };

        public static Optional<T> PresentOrElse<T>([DisallowNull] in T? value) where T : struct
            =>
            PresentOrElse<T?>(value).MapToNotNullOrThrow();
    }
}
