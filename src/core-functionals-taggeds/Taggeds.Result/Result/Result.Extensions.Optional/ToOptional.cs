#nullable enable

using static System.Optional;

namespace System
{
    partial class OptionalResultExtensions
    {
        public static Optional<TSuccess> ToOptional<TSuccess>(this Result<TSuccess, Unit> result)
            where TSuccess : notnull
            =>
            result.Fold(Present<TSuccess>, ToAbsent<Unit, TSuccess>);
    }
}
