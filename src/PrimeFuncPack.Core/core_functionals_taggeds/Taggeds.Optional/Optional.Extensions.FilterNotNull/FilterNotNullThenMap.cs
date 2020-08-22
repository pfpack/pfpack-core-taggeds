#nullable enable

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNullThenMap<T>(this in Optional<T?> optional) where T : class
            =>
            optional
            .FilterNotNull()
            .Map(value => value ?? throw CreateExpectedNotNullOrAbsentException());

        public static Optional<T> FilterNotNullThenMap<T>(this in Optional<T?> optional) where T : struct
            =>
            optional
            .FilterNotNull()
            .Map(value => value ?? throw CreateExpectedNotNullOrAbsentException());
    }
}
