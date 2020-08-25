#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TaggedUnion<TResultFirst, TResultSecond> ImplMap<TResultFirst, TResultSecond>(
            Func<TFirst, TResultFirst> onFirst,
            Func<TSecond, TResultSecond> onSecond)
        {
            _ = onFirst ?? throw new ArgumentNullException(nameof(onFirst));
            _ = onSecond ?? throw new ArgumentNullException(nameof(onSecond));

            return ImplFold(
                value => value.InvokePipe(onFirst).InvokePipe(TaggedUnion<TResultFirst, TResultSecond>.First),
                value => value.InvokePipe(onSecond).InvokePipe(TaggedUnion<TResultFirst, TResultSecond>.Second))
            .OrElse(
                () => default);
        }
    }
}
