#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Optional
    {
        public static Optional<T> PresentOrElse<T>([DisallowNull] T value)
            =>
            value switch { not null => Optional<T>.Present(value), _ => Optional<T>.Absent };

        public static Optional<T> PresentOrElse<T>([DisallowNull] T? value) where T : struct
            =>
            value switch { not null => Optional<T>.Present(value.Value), _ => Optional<T>.Absent };
    }
}
