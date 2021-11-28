namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
            =>
            optional.Filter(value => value is not null).Map(InnerToNonNullable);

        public static Optional<T> FilterNotNull<T>(this Optional<T?> optional)
            where T : struct
            =>
            optional.Filter(value => value is not null).Map(InnerToNonNullable);
    }
}
