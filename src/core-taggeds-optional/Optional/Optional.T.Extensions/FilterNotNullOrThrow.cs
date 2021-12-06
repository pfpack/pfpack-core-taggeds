namespace System;

partial class OptionalExtensions
{
    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
        =>
        optional.FlatMap(value => InnerFilterNotNullOrThrow(value, InnerCreateExpectedNotNullException));

    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
        where T : struct
        =>
        optional.FlatMap(value => InnerFilterNotNullOrThrow(value, InnerCreateExpectedNotNullException));

    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return optional.FlatMap(value => InnerFilterNotNullOrThrow(value, exceptionFactory));
    }

    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
        where T : struct
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return optional.FlatMap(value => InnerFilterNotNullOrThrow(value, exceptionFactory));
    }

    private static Optional<T> InnerFilterNotNullOrThrow<T>(T? value, Func<Exception> exceptionFactory)
        =>
        value is not null ? new(value) : throw exceptionFactory.Invoke();

    private static Optional<T> InnerFilterNotNullOrThrow<T>(T? value, Func<Exception> exceptionFactory)
        where T : struct
        =>
        value is not null ? new(value.GetValueOrDefault()) : throw exceptionFactory.Invoke();

    private static InvalidOperationException InnerCreateExpectedNotNullException()
        =>
        new("The value is expected to be not null.");
}
