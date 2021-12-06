namespace System;

// TODO: Consider to remove the class in v3.0
[Obsolete(InnerClassObsoleteMessage, error: true)]
public static partial class FilterNotNullOptionalExtensions
{
    private const string InnerClassObsoleteMessage
        =
        "This class is obsolete. Use FilterNotNull and FilterNotNullOrThrow extension methods instead.";

    private const string InnerFilterNotNullMethodObsoleteMessage
        =
        "This method is obsolete. Call FilterNotNull extension method instead.";

    private const string InnerFilterNotNullOrThrowMethodObsoleteMessage
        =
        "This method is obsolete. Call FilterNotNullOrThrow extension method instead.";

    [Obsolete(InnerFilterNotNullMethodObsoleteMessage, error: true)]
    public static Optional<T> FilterNotNull<T>(Optional<T?> optional)
        =>
        optional.FilterNotNull();

    [Obsolete(InnerFilterNotNullMethodObsoleteMessage, error: true)]
    public static Optional<T> FilterNotNull<T>(Optional<T?> optional)
        where T : struct
        =>
        optional.FilterNotNull();

    [Obsolete(InnerFilterNotNullOrThrowMethodObsoleteMessage, error: true)]
    public static Optional<T> FilterNotNullOrThrow<T>(Optional<T?> optional)
        =>
        optional.FilterNotNullOrThrow();

    [Obsolete(InnerFilterNotNullOrThrowMethodObsoleteMessage, error: true)]
    public static Optional<T> FilterNotNullOrThrow<T>(Optional<T?> optional)
        where T : struct
        =>
        optional.FilterNotNullOrThrow();

    [Obsolete(InnerFilterNotNullOrThrowMethodObsoleteMessage, error: true)]
    public static Optional<T> FilterNotNullOrThrow<T>(Optional<T?> optional, Func<Exception> exceptionFactory)
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return optional.FilterNotNullOrThrow(exceptionFactory);
    }

    [Obsolete(InnerFilterNotNullOrThrowMethodObsoleteMessage, error: true)]
    public static Optional<T> FilterNotNullOrThrow<T>(Optional<T?> optional, Func<Exception> exceptionFactory)
        where T : struct
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return optional.FilterNotNullOrThrow(exceptionFactory);
    }
}
