#nullable enable

namespace System
{
    public static class TaggedUnionsExtensions
    {
        public static Optional<T> ToOptional<T>(this in TaggedUnion<T, Unit> tagged)
            =>
            tagged switch
            {
                var first when first.IsFirst
                =>
                first.TryGetFirst(),

                var second when second.IsSecond
                =>
                default,

                _ =>
                throw new InvalidOperationException("The Tagged Union is not initialized.")
            };

        public static TaggedUnion<T, Unit> ToTaggedUnion<T>(this in Optional<T> optional)
            =>
            optional switch
            {
                var present when present.IsPresent
                =>
                TaggedUnion<T, Unit>.CreateFirst(present.OrThrow()),

                _ =>
                TaggedUnion<T, Unit>.CreateSecond(default)
            };
    }
}
