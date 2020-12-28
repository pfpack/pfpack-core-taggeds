#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Optional
    {
        public static Optional<T> PresentOrThrow<T>([DisallowNull] T value)
            =>
            value switch
            {
                not null => Optional<T>.Present(value),
                _ => throw new ArgumentNullException(nameof(value))
            };

        public static Optional<T> PresentOrThrow<T>([DisallowNull] T? value) where T : struct
            =>
            value switch
            {
                not null => Optional<T>.Present(value.Value),
                _ => throw new ArgumentNullException(nameof(value))
            };
    }
}
