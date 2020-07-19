#nullable enable

namespace System
{
    partial class OptionalExtensions
    {
        public static Optional<T> NotNullOrAbsentMapped<T>(this in Optional<T?> optional) where T : class
            =>
            optional.FlatMap(
                value => value switch
                {
                    null => default,
                    var notnull => Optional<T>.Present(notnull)
                });

        public static Optional<T> NotNullOrAbsentMapped<T>(this in Optional<T?> optional) where T : struct
            =>
            optional.FlatMap(
                value => value switch
                {
                    null => default,
                    T notnull => Optional<T>.Present(notnull)
                });
    }
}
