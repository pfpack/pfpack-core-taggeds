#nullable enable

using static System.Predicates;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNullThenMap<T>(this Optional<T?> optional) where T : class
            =>
            optional
            .Filter(IsNotNull)
            .Map(InternalMapNotNull);

        public static Optional<T> FilterNotNullThenMap<T>(this Optional<T?> optional) where T : struct
            =>
            optional
            .Filter(IsNotNull)
            .Map(InternalMapNotNull);
    }
}
