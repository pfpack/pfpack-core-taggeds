#nullable enable

namespace System
{
    partial class OptionalNotNullExtensions
    {
        public static Optional<T> FilterNotNullOrThrow<T>(this in Optional<T> optional)
            =>
            optional.FilterNotNullOrThrow(CreatePresentAndNullException);

        public static Optional<T> FilterNotNullOrThrow<T>(this in Optional<T> optional, Func<Exception> exceptionFactory)
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            return optional.Filter(
                value => value switch
                {
                    null => throw exceptionFactory.Invoke(),
                    _ => true
                });
        }
    }
}
