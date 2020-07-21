#nullable enable

namespace System
{
    partial class OptionalNotNullExtensions
    {
        public static Optional<T> FilterNotNullOrThrow<T>(this in Optional<T> optional)
            =>
            optional.FilterNotNullOrThrow(CreateNoNotnullPresentException);

        public static Optional<T> FilterNotNullOrThrow<T>(this in Optional<T> optional, Func<Exception> exceptionFactory)
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            optional.OnAbsent(
                () => throw exceptionFactory.Invoke());

            optional.OnPresent(
                value => (value ?? throw exceptionFactory.Invoke()).ToUnit());

            return optional;
        }
    }
}
