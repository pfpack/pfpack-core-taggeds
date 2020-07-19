#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<T> PresentOrThrowMapped<T>(in T? value) where T : class
            =>
            PresentOrThrow(value).NotNullOrThrowMapped();

        public static Optional<T> PresentOrThrowMapped<T>(in T? value) where T : struct
            =>
            PresentOrThrow(value).NotNullOrThrowMapped();

        public static Optional<T> PresentOrElseMapped<T>(in T? value) where T : class
            =>
            PresentOrElse(value).NotNullOrAbsentOrThrowMapped();

        public static Optional<T> PresentOrElseMapped<T>(in T? value) where T : struct
            =>
            PresentOrElse(value).NotNullOrAbsentOrThrowMapped();
    }
}
