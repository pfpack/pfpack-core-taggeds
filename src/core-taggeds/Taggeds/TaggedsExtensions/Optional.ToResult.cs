namespace System
{
    partial class TaggedsExtensions
    {
        // TODO: Consider to shorten TSuccess to T in v2.0, or in v1.2 if no breaking change
        public static Result<TSuccess, Unit> ToResult<TSuccess>(this Optional<TSuccess> optional)
            =>
            optional.Fold<Result<TSuccess, Unit>>(
                value => new(value),
                static () => new(default(Unit)));
    }
}
