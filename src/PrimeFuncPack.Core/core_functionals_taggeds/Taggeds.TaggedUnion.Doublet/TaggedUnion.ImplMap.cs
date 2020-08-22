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
                value => value.DoPipe(onFirst).DoPipe(TaggedUnion<TResultFirst, TResultSecond>.CreateFirst),
                value => value.DoPipe(onSecond).DoPipe(TaggedUnion<TResultFirst, TResultSecond>.CreateSecond))
            .OrElse(
                () => default);
    }
}
