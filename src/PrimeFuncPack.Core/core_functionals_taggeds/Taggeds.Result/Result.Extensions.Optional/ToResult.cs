#nullable enable


namespace System
{
    partial class OptionalResultExtensions
    {
        public static Result<T, Unit> ToResult<T>(this Optional<T> optional) where T : notnull
            =>
            throw new NotImplementedException(); // TODO: Implement
    }
}
