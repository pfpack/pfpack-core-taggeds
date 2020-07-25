#nullable enable

namespace System
{
    partial struct TaggedUnion<TTag, TFirst, TSecond>
    {
        public TaggedUnion<TTag, TResultFirst, TSecond> MapFirst<TResultFirst>(
            in Func<TFirst, TResultFirst> mapFirst)
            where TResultFirst : TTag
            =>
            Map(mapFirst, second => second);

        public TaggedUnion<TTag, TFirst, TResultSecond> MapSecond<TResultSecond>(
            in Func<TSecond, TResultSecond> mapSecond)
            where TResultSecond : TTag
            =>
            Map(first => first, mapSecond);

        public TaggedUnion<TTag, TResultFirst, TResultSecond> Map<TResultFirst, TResultSecond>(
            in Func<TFirst, TResultFirst> mapFirst,
            in Func<TSecond, TResultSecond> mapSecond)
            where TResultFirst : TTag
            where TResultSecond : TTag
            =>
            Map<TTag, TResultFirst, TResultSecond>(mapFirst, mapSecond);

        public TaggedUnion<TResultTag, TResultFirst, TResultSecond> Map<TResultTag, TResultFirst, TResultSecond>(
            in Func<TFirst, TResultFirst> mapFirst,
            in Func<TSecond, TResultSecond> mapSecond)
            where TResultFirst : TResultTag
            where TResultSecond : TResultTag
        {
            if (mapFirst is null)
            {
                throw new ArgumentNullException(nameof(mapFirst));
            }

            if (mapSecond is null)
            {
                throw new ArgumentNullException(nameof(mapSecond));
            }

            return (boxFirst, boxSecond) switch
            {
                (Box<TFirst> presentFirst, _)
                =>
                TaggedUnion<TResultTag, TResultFirst, TResultSecond>.CreateFirst(mapFirst(presentFirst)),

                (_, Box<TSecond> presentSecond)
                =>
                TaggedUnion<TResultTag, TResultFirst, TResultSecond>.CreateSecond(mapSecond(presentSecond)),

                _ => throw CreateNotInitializedException()
            };
        }
    }
}
