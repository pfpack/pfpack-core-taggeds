#nullable enable


namespace System
{
    partial class OptionalResultExtensions
    {
        public static Result<T, Unit> ToResult<T>(this Optional<T> optional) where T : notnull
            =>
            optional.Fold(Result<T, Unit>.Success, () => Result<T, Unit>.Failure(default));
    }
}
