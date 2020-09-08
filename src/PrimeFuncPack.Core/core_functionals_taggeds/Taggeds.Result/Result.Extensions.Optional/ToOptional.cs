#nullable enable

namespace System
{
    partial class OptionalResultExtensions
    {
        public static Optional<T> ToOptional<T>(this Result<T, Unit> result) where T : notnull
            =>
            result.Fold(Optional<T>.Present, _ => Optional<T>.Absent);
    }
}
