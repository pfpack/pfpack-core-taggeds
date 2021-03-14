#nullable enable

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional)
            where T : class
            =>
            optional.FilterNotNullOrThrowThenMap(CreateExpectedNotNullOrAbsentException);

        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional,
            Func<Exception> exceptionFactory)
            where T : class
            =>
            optional
            .FilterNotNullOrThrow(exceptionFactory)
            .Map(static value => value ?? throw CreateExpectedNotNullOrAbsentException());

        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional)
            where T : struct
            =>
            optional.FilterNotNullOrThrowThenMap(CreateExpectedNotNullOrAbsentException);

        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional,
            Func<Exception> exceptionFactory)
            where T : struct
            =>
            optional
            .FilterNotNullOrThrow(exceptionFactory)
            .Map(static value => value ?? throw CreateExpectedNotNullOrAbsentException());
    }
}
