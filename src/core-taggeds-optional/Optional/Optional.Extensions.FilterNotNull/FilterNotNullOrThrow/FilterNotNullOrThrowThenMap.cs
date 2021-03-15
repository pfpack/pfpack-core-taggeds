#nullable enable

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional)
            where T : class
            =>
            optional
            .InternalFilterNotNullOrThrow()
            .Map(static value => value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked());

        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional,
            Func<Exception> exceptionFactory)
            where T : class
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional
                .InternalFilterNotNullOrThrow(exceptionFactory)
                .Map(static value => value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked());
        }

        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional)
            where T : struct
            =>
            optional
            .InternalFilterNotNullOrThrow()
            .Map(static value => value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked());

        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional,
            Func<Exception> exceptionFactory)
            where T : struct
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional
                .InternalFilterNotNullOrThrow(exceptionFactory)
                .Map(static value => value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked());
        }
    }
}
