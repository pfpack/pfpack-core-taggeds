#nullable enable

namespace System
{
    partial class OptionalNotNullExtensions
    {
        public static Optional<T> FilterNotNullOrAbsentOrThrow<T>(this in Optional<T> optional)
            =>
            optional.FilterNotNullOrAbsentOrThrow(CreateNoNotnullPresentOrAbsentException);

        public static Optional<T> FilterNotNullOrAbsentOrThrow<T>(this in Optional<T> optional, Func<Exception> exceptionFactory)
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            optional.OnPresent(
                value => (value ?? throw exceptionFactory.Invoke()).ToUnit());

            return optional;
        }
    }
}
