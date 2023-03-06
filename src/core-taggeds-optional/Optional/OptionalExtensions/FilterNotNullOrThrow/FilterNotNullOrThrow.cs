namespace System;

partial class OptionalExtensions
{
    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
        =>
        optional.FlatMap(
            value => InnerFilterNotNullOrThrowMap(value, InnerCreateExpectedNotNullException));

    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
        where T : struct
        =>
        optional.FlatMap(
            value => InnerFilterNotNullOrThrowMap(value, InnerCreateExpectedNotNullException));

    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return optional.FlatMap(
            value => InnerFilterNotNullOrThrowMap(value, exceptionFactory));
    }

    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
        where T : struct
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return optional.FlatMap(
            value => InnerFilterNotNullOrThrowMap(value, exceptionFactory));
    }
}
