#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Optional
    {
        public static Optional<T> PresentOrThrow<T>([DisallowNull] T value)
            =>
            Optional<T>.Present(value ?? throw new ArgumentNullException(nameof(value)));

        public static Optional<T> PresentOrThrow<T>([DisallowNull] T? value) where T : struct
            =>
            Optional<T>.Present(value ?? throw new ArgumentNullException(nameof(value)));
    }
}
