#nullable enable

namespace PrimeFuncPack
{
    partial class Optional
    {
        public static Optional<T> Absent<T>()
            =>
            Optional<T>.Absent;

        public static Optional<T> PresentEvenIfNull<T>(in T value)
            =>
            Optional<T>.PresentEvenIfNull(value);

        public static Optional<T> PresentOrThrowIfNull<T>(in T value)
            =>
            Optional<T>.PresentOrThrowIfNull(value);

        public static Optional<T> PresentOrAbsentIfNull<T>(in T value)
            =>
            Optional<T>.PresentOrAbsentIfNull(value);
    }
}
