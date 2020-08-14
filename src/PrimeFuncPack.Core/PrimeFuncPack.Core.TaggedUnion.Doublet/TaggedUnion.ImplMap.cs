#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TaggedUnion<TResultFirst, TResultSecond> ImplMapOrThrow<TResultFirst, TResultSecond>(
            in Func<TFirst, TResultFirst> onFirst,
            in Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMap(onFirst, onSecond).OrThrow(CreateNotInitializedException);

        private TaggedUnion<TResultFirst, TResultSecond> ImplMapOrElse<TResultFirst, TResultSecond>(
            in Func<TFirst, TResultFirst> onFirst,
            in Func<TSecond, TResultSecond> onSecond)
            =>
            ImplMap(onFirst, onSecond).OrElse(() => default);

        private Optional<TaggedUnion<TResultFirst, TResultSecond>> ImplMap<TResultFirst, TResultSecond>(
            Func<TFirst, TResultFirst> onFirst,
            Func<TSecond, TResultSecond> onSecond)
            =>
            ImplFold(
                value => TaggedUnion<TResultFirst, TResultSecond>.CreateFirst(onFirst.Invoke(value)),
                value => TaggedUnion<TResultFirst, TResultSecond>.CreateSecond(onSecond.Invoke(value)));
    }
}
