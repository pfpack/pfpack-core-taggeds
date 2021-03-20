#nullable enable

using static System.Predicates;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
            =>
            optional.Filter(IsNotNull).Map(InternalToNonNullable);

        public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
            where T : struct
            =>
            optional.Filter(IsNotNull).Map(InternalToNonNullable);
    }
}
