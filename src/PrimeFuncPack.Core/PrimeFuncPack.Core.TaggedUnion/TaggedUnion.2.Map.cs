#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TResultFirst, TSecond> MapFirst<TResultFirst>(
            in Func<TFirst, TResultFirst> mapFirst)
            =>
            ImplMap(
                mapFirst,
                second => second);

        public TaggedUnion<TFirst, TResultSecond> MapSecond<TResultSecond>(
            in Func<TSecond, TResultSecond> mapSecond)
            =>
            ImplMap(
                first => first,
                mapSecond);

        public TaggedUnion<TResultFirst, TResultSecond> Map<TResultFirst, TResultSecond>(
            in Func<TFirst, TResultFirst> mapFirst,
            in Func<TSecond, TResultSecond> mapSecond)
            =>
            ImplMap(
                mapFirst,
                mapSecond);
    }
}
