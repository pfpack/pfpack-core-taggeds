#nullable enable

using static System.NullPredicates;

namespace System
{
    partial class OptionalNotNullExtensions
    {
        public static Optional<T> FilterNotNullOrAbsent<T>(this in Optional<T> optional)
            =>
            optional.Filter(IsNotNull);
    }
}
