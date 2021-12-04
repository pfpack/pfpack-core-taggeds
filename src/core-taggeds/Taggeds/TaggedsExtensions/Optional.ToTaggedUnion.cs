namespace System
{
    partial class TaggedsExtensions
    {
        public static TaggedUnion<T, Unit> ToTaggedUnion<T>(this Optional<T> optional)
            =>
            optional.Fold<TaggedUnion<T, Unit>>(
                value => new(value),
                static () => new(default(Unit)));
    }
}
