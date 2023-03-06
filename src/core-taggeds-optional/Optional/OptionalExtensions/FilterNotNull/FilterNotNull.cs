namespace System;

partial class OptionalExtensions
{
    public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
        =>
        optional.FlatMap(InnerFilterNotNullMap);

    public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
        where T : struct
        =>
        optional.FlatMap(InnerFilterNotNullMap);
}
