#nullable enable

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T> optional)
            =>
            optional.FilterNotNullOrThrow(CreateExpectedNotNullOrAbsentException);

        public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T> optional, Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return optional.Filter(value => value switch
            {
                not null => true,
                _ => throw exceptionFactory.Invoke()
            });
        }
    }
}
