#nullable enable

using static System.Optional;

namespace System
{
    partial class OptionalTaggedUnionExtensions
    {
        public static Optional<T> ToOptional<T>(this TaggedUnion<T, Unit> union)
            =>
            union.Fold(Present<T>, Absent<T>);
    }
}
