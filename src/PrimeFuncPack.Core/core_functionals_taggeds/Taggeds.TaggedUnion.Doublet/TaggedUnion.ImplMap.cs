#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TaggedUnion<TResultFirst, TResultSecond> ImplMap<TResultFirst, TResultSecond>(
            Func<TFirst, TResultFirst> onFirst,
            Func<TSecond, TResultSecond> onSecond)
            =>
            ImplFold(
                value => TaggedUnion<TResultFirst, TResultSecond>.CreateFirst(onFirst.Invoke(value)),
                value => TaggedUnion<TResultFirst, TResultSecond>.CreateSecond(onSecond.Invoke(value)))
            .OrElse(
                () => default);
    }
}
