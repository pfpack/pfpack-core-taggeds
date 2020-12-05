#nullable enable

namespace System
{
    partial class OptionalResultExtensions
    {
        public static Optional<TSuccess> ToOptional<TSuccess>(this Result<TSuccess, Unit> result)
            where TSuccess : notnull
            =>
            result.Fold(Optional<TSuccess>.Present, static _ => Optional<TSuccess>.Absent);
    }
}
