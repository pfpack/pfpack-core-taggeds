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
                value => value.InvokePipe(onFirst).InvokePipe(TaggedUnion<TResultFirst, TResultSecond>.First),
                value => value.InvokePipe(onSecond).InvokePipe(TaggedUnion<TResultFirst, TResultSecond>.Second))
            .OrElse(
                () => default);
    }
}
