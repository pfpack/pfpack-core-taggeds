#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Optional
    {
        public static Optional<T> Absent<T>()
            =>
            Optional<T>.Absent;

        public static Optional<T> Present<T>(in T value)
            =>
            Optional<T>.Present(value);

        public static Optional<T> PresentOrThrow<T>([DisallowNull] in T value)
            =>
            Optional<T>.PresentOrThrow(value);

        public static Optional<T> PresentOrElse<T>(in T value)
            =>
            Optional<T>.PresentOrElse(value);
    }
}
