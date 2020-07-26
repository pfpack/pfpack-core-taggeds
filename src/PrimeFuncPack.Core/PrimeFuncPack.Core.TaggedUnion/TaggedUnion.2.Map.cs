#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TResultFirst, TSecond> MapFirst<TResultFirst>(
            in Func<TFirst, TResultFirst> mapFirst)
            =>
            Map(
                mapFirst,
                second => second);

        public TaggedUnion<TFirst, TResultSecond> MapSecond<TResultSecond>(
            in Func<TSecond, TResultSecond> mapSecond)
            =>
            Map(
                first => first,
                mapSecond);

        public TaggedUnion<TResultFirst, TResultSecond> Map<TResultFirst, TResultSecond>(
            in Func<TFirst, TResultFirst> mapFirst,
            in Func<TSecond, TResultSecond> mapSecond)
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
                TaggedUnion<TResultFirst, TResultSecond>.CreateFirst(mapFirst(presentFirst)),

                (_, Box<TSecond> presentSecond)
                =>
                TaggedUnion<TResultFirst, TResultSecond>.CreateSecond(mapSecond(presentSecond)),

                _ => throw CreateNotInitializedException()
            };
        }
    }
}
