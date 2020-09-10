#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TaggedUnion<TResultFirst, TResultSecond> ImplMap<TResultFirst, TResultSecond>(
            Func<TFirst, TResultFirst> mapFirst,
            Func<TSecond, TResultSecond> mapSecond)
        {
            _ = mapFirst ?? throw new ArgumentNullException(nameof(mapFirst));
            _ = mapSecond ?? throw new ArgumentNullException(nameof(mapSecond));

            return ImplFold(
                value => TaggedUnion<TResultFirst, TResultSecond>.First(mapFirst.Invoke(value)),
                value => TaggedUnion<TResultFirst, TResultSecond>.Second(mapSecond.Invoke(value)))
            .OrElse(
                () => default);
        }
    }
}
