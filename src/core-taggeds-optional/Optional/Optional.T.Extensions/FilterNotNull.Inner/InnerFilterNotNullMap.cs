namespace System;

partial class OptionalExtensions
{
    private static Optional<T> InnerFilterNotNullMap<T>(T? value)
        =>
        value is not null
            ? new(value)
            : default;

    private static Optional<T> InnerFilterNotNullMap<T>(T? value)
        where T : struct
        =>
        value is not null
            ? new(value.GetValueOrDefault())
            : default;
}
