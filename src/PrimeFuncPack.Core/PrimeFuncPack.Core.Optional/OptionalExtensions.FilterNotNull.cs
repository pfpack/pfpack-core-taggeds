#nullable enable

using static System.NullPredicates;

namespace System
{
    partial class OptionalExtensions
    {
        public static Optional<T> FilterNotNull<T>(this in Optional<T> optional)
            =>
            optional.Filter(IsNotNull);
    }
}
