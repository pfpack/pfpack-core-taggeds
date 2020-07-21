#nullable enable

using static System.OptionalExceptionFactories;

namespace System
{
    partial class OptionalExtensions
    {
        public static Optional<T> NotNullOrThrowMapped<T>(this in Optional<T?> optional)
            where T : class
            =>
            optional.NotNullOrThrowMapped(CreateNoNotNullValueException);

        public static Optional<T> NotNullOrThrowMapped<T>(this in Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : class
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            return optional
                .NotNullOrThrow(exceptionFactory)
                .Map(value => value ?? throw new ArgumentNullException(nameof(value))); // Just to not to use ! (null-forgiving) operator
        }

        public static Optional<T> NotNullOrThrowMapped<T>(this in Optional<T?> optional)
            where T : struct
            =>
            optional.NotNullOrThrowMapped(CreateNoNotNullValueException);

        public static Optional<T> NotNullOrThrowMapped<T>(this in Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : struct
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            return optional
                .NotNullOrThrow(exceptionFactory)
                .Map(value => value ?? throw new ArgumentNullException(nameof(value))); // Just to not to use ! (null-forgiving) operator
        }
    }
}
