#nullable enable

namespace System
{
    partial class OptionalResultExtensions
    {
        [Obsolete(ObsoleteMessages.ToResult_ReservedForFutureUse, error: true)]
        public static Result<TSuccess, Unit> ToResult<TSuccess>(this Optional<TSuccess> optional)
            where TSuccess : notnull
            =>
            optional.Fold<Result<TSuccess, Unit>>(
                static value => value,
                static () => Unit.Value);
    }
}
