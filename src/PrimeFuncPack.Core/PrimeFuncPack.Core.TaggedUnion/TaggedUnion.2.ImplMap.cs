#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TaggedUnion<TResultFirst, TResultSecond> ImplMap<TResultFirst, TResultSecond>(
            Func<TFirst, TResultFirst> mapFirst,
            Func<TSecond, TResultSecond> mapSecond)
            =>
            ImplFold(
                first => TaggedUnion<TResultFirst, TResultSecond>.CreateFirst(mapFirst.Invoke(first)),
                second => TaggedUnion<TResultFirst, TResultSecond>.CreateSecond(mapSecond.Invoke(second)));
    }
}
