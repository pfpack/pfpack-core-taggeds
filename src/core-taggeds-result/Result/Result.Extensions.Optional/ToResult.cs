#nullable enable

namespace System
{
    partial class OptionalResultExtensions
    {
        public static Result<TSuccess, Unit> ToResult<TSuccess>(this Optional<TSuccess> optional)
            =>
            optional.Fold<Result<TSuccess, Unit>>(
                static value => new(value),
                static () => new(Unit.Value));
    }
}
