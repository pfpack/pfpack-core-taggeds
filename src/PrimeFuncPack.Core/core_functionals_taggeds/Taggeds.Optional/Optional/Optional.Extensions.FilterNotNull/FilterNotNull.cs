#nullable enable

using static System.ObjectPredicates;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        public static Optional<T> FilterNotNull<T>(this Optional<T> optional)
            =>
            optional.Filter(IsNotNull);
    }
}
