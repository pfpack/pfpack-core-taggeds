#nullable enable

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
            =>
            optional.InternalFilterNotNullOrThrow(CreateExpectedNotNullOrAbsentException);

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional.InternalFilterNotNullOrThrow(exceptionFactory);
        }

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
            where T : struct
            =>
            optional.InternalFilterNotNullOrThrow(CreateExpectedNotNullOrAbsentException);

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : struct
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional.InternalFilterNotNullOrThrow(exceptionFactory);
        }
    }
}
