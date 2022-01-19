namespace System;

partial class TaggedsExtensions
{
    public static Result<T, Unit> ToResult<T>(this Optional<T> optional)
        =>
        optional.Fold<Result<T, Unit>>(
            value => new(value),
            static () => new(default(Unit)));
}
