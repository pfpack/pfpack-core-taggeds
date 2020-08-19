#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TResultFirst, TSecond> MapFirst<TResultFirst>(
            in Func<TFirst, TResultFirst> onFirst)
            =>
            ImplMap(
                onFirst,
                value => value);

        public TaggedUnion<TFirst, TResultSecond> MapSecond<TResultSecond>(
            in Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMap(
                value => value,
                onSecond);

        public TaggedUnion<TResultFirst, TResultSecond> Map<TResultFirst, TResultSecond>(
            in Func<TFirst, TResultFirst> onFirst,
            in Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMap(
                onFirst,
                onSecond);
    }
}
