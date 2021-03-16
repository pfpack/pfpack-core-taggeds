#nullable enable

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
            =>
            optional
            .Filter(InternalCreateFilterNotNullOrThrowPredicate_Common<T>(CreateExpectedNotNullOrAbsentException))
            .Map(InternalMapToNonNullable);

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional
            .Filter(InternalCreateFilterNotNullOrThrowPredicate_Common<T>(exceptionFactory))
            .Map(InternalMapToNonNullable);
        }

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
            where T : struct
            =>
            optional
            .Filter(InternalCreateFilterNotNullOrThrowPredicate_Struct<T>(CreateExpectedNotNullOrAbsentException))
            .Map(InternalMapToNonNullable);

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : struct
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional
            .Filter(InternalCreateFilterNotNullOrThrowPredicate_Struct<T>(exceptionFactory))
            .Map(InternalMapToNonNullable);
        }
    }
}
