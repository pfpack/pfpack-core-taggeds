#nullable enable

using static System.NullPredicates;

namespace System
{
    partial class OptionalFilterNotNullExtensions
    {
        public static Optional<T> FilterNotNull<T>(this in Optional<T> optional)
            =>
            optional.Filter(IsNotNull);
    }
}
