#nullable enable

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNullOrThrow<T>(
            this Optional<T> optional)
            =>
            optional
            .Filter(CreateFilterNotNullOrThrowPredicate<T>());

        public static Optional<T> FilterNotNullOrThrow<T>(
            this Optional<T> optional,
            Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional
                .Filter(CreateFilterNotNullOrThrowPredicate<T>(exceptionFactory));
        }
    }
}
