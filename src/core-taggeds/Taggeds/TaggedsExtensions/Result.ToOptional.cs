namespace System;

partial class TaggedsExtensions
{
    public static Optional<T> ToOptional<T>(this Result<T, Unit> result)
        =>
        result.Fold<Optional<T>>(
            value => new(value),
            static _ => default);
}
