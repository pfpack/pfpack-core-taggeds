#nullable enable

namespace System
{
    partial class OptionalResultExtensions
    {
        public static Result<T, Unit> ToResultOrThrowOnNull<T>(this Optional<T> optional) where T : notnull
            =>
            optional
            .FilterNotNullOrThrow()
            .Fold(Result.Present<T>, Result.Absent<T>);
    }
}
