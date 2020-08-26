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
                value => value.InvokePipe(mapFirst).InvokePipe(TaggedUnion<TResultFirst, TResultSecond>.First),
                value => value.InvokePipe(mapSecond).InvokePipe(TaggedUnion<TResultFirst, TResultSecond>.Second))
            .OrElse(
                () => default);
        }
    }
}
