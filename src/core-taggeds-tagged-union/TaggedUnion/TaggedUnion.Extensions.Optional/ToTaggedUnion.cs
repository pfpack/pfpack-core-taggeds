#nullable enable

namespace System
{
    partial class OptionalTaggedUnionExtensions
    {
        public static TaggedUnion<T, Unit> ToTaggedUnion<T>(this Optional<T> optional)
            =>
            optional.Fold<TaggedUnion<T, Unit>>(
                static value => new(value),
                static () => new(Unit.Value));
    }
}
