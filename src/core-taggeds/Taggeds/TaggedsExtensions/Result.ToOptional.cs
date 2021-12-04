namespace System;

partial class TaggedsExtensions
{
    // TODO: Consider to shorten TSuccess to T in v2.0, or in v1.2 if no breaking change
    public static Optional<TSuccess> ToOptional<TSuccess>(this Result<TSuccess, Unit> result)
        =>
        result.Fold<Optional<TSuccess>>(
            value => new(value),
            static _ => default);
}
