#nullable enable

namespace System
{
    partial class OptionalNotNullExtensions
    {
        public static Optional<T> MapToNotNullOrThrow<T>(this in Optional<T?> optional)
            where T : class
            =>
            optional.MapToNotNullOrThrow(CreatePresentAndNullException);

        public static Optional<T> MapToNotNullOrThrow<T>(this in Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : class
            =>
            optional.Map(value => value ?? throw exceptionFactory.Invoke());

        public static Optional<T> MapToNotNullOrThrow<T>(this in Optional<T?> optional)
            where T : struct
            =>
            optional.MapToNotNullOrThrow(CreatePresentAndNullException);

        public static Optional<T> MapToNotNullOrThrow<T>(this in Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : struct
            =>
            optional.Map(value => value ?? throw exceptionFactory.Invoke());
    }
}
