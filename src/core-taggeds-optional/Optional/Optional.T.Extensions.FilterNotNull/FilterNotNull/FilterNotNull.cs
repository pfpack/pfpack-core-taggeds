namespace System;

partial class FilterNotNullOptionalExtensions
{
    public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
        =>
        optional.InnerFilterNotNull();

    public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
        where T : struct
        =>
        optional.InnerFilterNotNull();
}
