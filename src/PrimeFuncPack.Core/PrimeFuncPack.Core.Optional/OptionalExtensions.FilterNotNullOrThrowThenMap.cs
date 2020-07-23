#nullable enable

namespace System
{
    partial class OptionalExtensions
    {
        public static Optional<T> FilterNotNullOrThrowThenMap<T>(this in Optional<T?> optional)
            where T : class
            =>
            optional.FilterNotNullOrThrowThenMap(CreateExpectedToHaveNotNullOrBeAbsentException);

        public static Optional<T> FilterNotNullOrThrowThenMap<T>(this in Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : class
            =>
            optional
            .FilterNotNullOrThrow(exceptionFactory)
            .Map(value => value ?? throw CreateExpectedToHaveNotNullOrBeAbsentException());

        public static Optional<T> FilterNotNullOrThrowThenMap<T>(this in Optional<T?> optional)
            where T : struct
            =>
            optional.FilterNotNullOrThrowThenMap(CreateExpectedToHaveNotNullOrBeAbsentException);

        public static Optional<T> FilterNotNullOrThrowThenMap<T>(this in Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : struct
            =>
            optional
            .FilterNotNullOrThrow(exceptionFactory)
            .Map(value => value ?? throw CreateExpectedToHaveNotNullOrBeAbsentException());
    }
}
