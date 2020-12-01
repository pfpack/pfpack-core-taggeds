#nullable enable

namespace System
{
    partial class OptionalResultExtensions
    {
        public static Result<TSuccess, Unit> ToResultOrThrow<TSuccess>(this Optional<TSuccess> optional)
            where TSuccess : notnull
            =>
            optional.Fold<Result<TSuccess, Unit>>(
                static value => value ?? throw CreateSuccessNullException(nameof(optional)),
                static () => default(Unit));
    }
}
