#nullable enable

namespace System
{
    partial class OptionalFilterNotNullExtensions
    {
        public static Optional<T> FilterNotNullOrThrow<T>(this in Optional<T> optional)
            =>
            optional.FilterNotNullOrThrow(CreateExpectedNotNullOrAbsentException);

        public static Optional<T> FilterNotNullOrThrow<T>(this in Optional<T> optional, Func<Exception> exceptionFactory)
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
