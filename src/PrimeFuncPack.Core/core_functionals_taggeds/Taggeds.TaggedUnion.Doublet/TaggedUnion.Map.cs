#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TResultFirst, TSecond> MapFirstOrThrow<TResultFirst>(
            in Func<TFirst, TResultFirst> onFirst)
            =>
            ImplMapOrThrow(
                onFirst,
                value => value);

        public TaggedUnion<TFirst, TResultSecond> MapSecondOrThrow<TResultSecond>(
            in Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMapOrThrow(
                value => value,
                onSecond);

        public TaggedUnion<TResultFirst, TResultSecond> MapOrThrow<TResultFirst, TResultSecond>(
            in Func<TFirst, TResultFirst> onFirst,
            in Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMapOrThrow(
                onFirst,
                onSecond);

        public TaggedUnion<TResultFirst, TSecond> MapFirstOrElse<TResultFirst>(
            in Func<TFirst, TResultFirst> onFirst)
            =>
            ImplMapOrElse(
                onFirst,
                value => value);

        public TaggedUnion<TFirst, TResultSecond> MapSecondOrElse<TResultSecond>(
            in Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMapOrElse(
                value => value,
                onSecond);

        public TaggedUnion<TResultFirst, TResultSecond> MapOrElse<TResultFirst, TResultSecond>(
            in Func<TFirst, TResultFirst> onFirst,
            in Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMapOrElse(
                onFirst,
                onSecond);
    }
}
