namespace System;

// TODO: Remove the class in v3.0
[Obsolete("This class is obsolete. Use FilterNotNull and FilterNotNullOrThrow extension methods instead.", error: true)]
public static partial class FilterNotNullOptionalExtensions
{
    private const string ObsoleteMessage_FilterNotNull
        =
        "This method is obsolete. Call FilterNotNull extension method instead.";

    private const string ObsoleteMessage_FilterNotNullOrThrow
        =
        "This method is obsolete. Call FilterNotNullOrThrow extension method instead.";

    [Obsolete(ObsoleteMessage_FilterNotNull, error: true)]
    public static Optional<T> FilterNotNull<T>(Optional<T?> optional)
        =>
        optional.FilterNotNull();

    [Obsolete(ObsoleteMessage_FilterNotNull, error: true)]
    public static Optional<T> FilterNotNull<T>(Optional<T?> optional)
        where T : struct
        =>
        optional.FilterNotNull();

    [Obsolete(ObsoleteMessage_FilterNotNullOrThrow, error: true)]
    public static Optional<T> FilterNotNullOrThrow<T>(Optional<T?> optional)
        =>
        optional.FilterNotNullOrThrow();

    [Obsolete(ObsoleteMessage_FilterNotNullOrThrow, error: true)]
    public static Optional<T> FilterNotNullOrThrow<T>(Optional<T?> optional)
        where T : struct
        =>
        optional.FilterNotNullOrThrow();

    [Obsolete(ObsoleteMessage_FilterNotNullOrThrow, error: true)]
    public static Optional<T> FilterNotNullOrThrow<T>(Optional<T?> optional, Func<Exception> exceptionFactory)
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return optional.FilterNotNullOrThrow(exceptionFactory);
    }

    [Obsolete(ObsoleteMessage_FilterNotNullOrThrow, error: true)]
    public static Optional<T> FilterNotNullOrThrow<T>(Optional<T?> optional, Func<Exception> exceptionFactory)
        where T : struct
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return optional.FilterNotNullOrThrow(exceptionFactory);
    }
}
