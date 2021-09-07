#nullable enable

namespace System
{
    partial class TaggedsExtensions
    {
        public static Optional<TSuccess> ToOptional<TSuccess>(this Result<TSuccess, Unit> result)
            =>
            result.Fold(Optional<TSuccess>.Present, static _ => default);
    }
}
