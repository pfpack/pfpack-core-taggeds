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
            Optional<T>.Present(value ?? throw new ArgumentNullException(nameof(value)));

        public static Optional<T> PresentOrElse<T>([DisallowNull] in T value)
            =>
            value switch { not null => Optional<T>.Present(value), _ => default };

        public static Optional<T> PresentOrElse<T>([DisallowNull] in T? value) where T : struct
            =>
            value switch { not null => Optional<T>.Present((T)value), _ => default };

        public static Optional<T> FromBox<T>(in Box<T>? box)
            =>
            box switch { not null => Optional<T>.Present(box), _ => default };
    }
}
