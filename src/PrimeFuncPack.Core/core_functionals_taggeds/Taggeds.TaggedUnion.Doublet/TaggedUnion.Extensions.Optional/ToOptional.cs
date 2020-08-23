#nullable enable

namespace System
{
    partial class OptionalTaggedUnionExtensions
    {
        public static Optional<T> ToOptional<T>(this TaggedUnion<T, Unit> union)
            =>
            union.Fold(Optional<T>.Present, _ => default);
    }
}
