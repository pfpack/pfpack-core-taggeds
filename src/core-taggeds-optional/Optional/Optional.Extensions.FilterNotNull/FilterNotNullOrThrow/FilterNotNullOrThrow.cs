#nullable enable

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
            =>
            optional
            .Filter(value => value is not null ? true : throw CreateExpectedNotNullOrAbsentException())
            .Map(value => value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked());

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional
            .Filter(value => value is not null ? true : throw exceptionFactory.Invoke())
            .Map(value => value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked());
        }

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
            where T : struct
            =>
            optional
            .Filter(value => value is not null ? true : throw CreateExpectedNotNullOrAbsentException())
            .Map(value => value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked());

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : struct
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional
            .Filter(value => value is not null ? true : throw exceptionFactory.Invoke())
            .Map(value => value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked());
        }
    }
}
