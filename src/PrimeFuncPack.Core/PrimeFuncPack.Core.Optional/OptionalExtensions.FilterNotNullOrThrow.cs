#nullable enable

namespace System
{
    partial class OptionalExtensions
    {
        public static Optional<T> FilterNotNullOrThrow<T>(this in Optional<T> optional)
            =>
            optional.FilterNotNullOrThrow(CreateExpectedToHaveNotNullOrBeAbsentException);

        public static Optional<T> FilterNotNullOrThrow<T>(this in Optional<T> optional, Func<Exception> exceptionFactory)
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            return optional.Filter(value => value switch
            {
                null => throw exceptionFactory.Invoke(),
                _ => true
            });
        }
    }
}
