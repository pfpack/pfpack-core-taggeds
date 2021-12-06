namespace System;

partial class OptionalExtensions
{
    public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
        =>
        optional.FlatMap<T>(value => value is not null ? new(value) : default);

    public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
        where T : struct
        =>
        optional.FlatMap<T>(value => value is not null ? new(value.GetValueOrDefault()) : default);
}
