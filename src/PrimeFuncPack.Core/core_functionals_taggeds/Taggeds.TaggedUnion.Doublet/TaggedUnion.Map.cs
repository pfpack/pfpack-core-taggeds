#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TResultFirst, TSecond> MapFirst<TResultFirst>(
            Func<TFirst, TResultFirst> onFirst)
            =>
            ImplMap(onFirst, Do.Pass);

        public TaggedUnion<TFirst, TResultSecond> MapSecond<TResultSecond>(
            Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMap(Do.Pass, onSecond);

        public TaggedUnion<TResultFirst, TResultSecond> Map<TResultFirst, TResultSecond>(
            Func<TFirst, TResultFirst> onFirst,
            Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMap(onFirst, onSecond);
    }
}
