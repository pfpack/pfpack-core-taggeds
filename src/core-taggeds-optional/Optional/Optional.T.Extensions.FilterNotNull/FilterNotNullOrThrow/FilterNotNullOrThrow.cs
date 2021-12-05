namespace System;

partial class FilterNotNullOptionalExtensions
{
    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
        =>
        optional.InnerFilterNotNullOrThrow(InnerCreateExpectedNotNullOrAbsentException);

    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
        =>
        optional.InnerFilterNotNullOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));

    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional)
        where T : struct
        =>
        optional.InnerFilterNotNullOrThrow(InnerCreateExpectedNotNullOrAbsentException);

    public static Optional<T> FilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
        where T : struct
        =>
        optional.InnerFilterNotNullOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));

    private static InvalidOperationException InnerCreateExpectedNotNullOrAbsentException()
        =>
        new("The optional is expected to have a not null value or to be absent.");
}
