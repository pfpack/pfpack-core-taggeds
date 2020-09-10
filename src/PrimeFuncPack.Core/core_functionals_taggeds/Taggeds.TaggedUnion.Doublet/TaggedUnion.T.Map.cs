#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TResultFirst, TSecond> MapFirst<TResultFirst>(
            Func<TFirst, TResultFirst> mapFirst)
            =>
            ImplMap(mapFirst, Pipeline.Pipe);

        public TaggedUnion<TFirst, TResultSecond> MapSecond<TResultSecond>(
            Func<TSecond, TResultSecond> mapSecond)
            =>
            ImplMap(Pipeline.Pipe, mapSecond);

        public TaggedUnion<TResultFirst, TResultSecond> Map<TResultFirst, TResultSecond>(
            Func<TFirst, TResultFirst> mapFirst,
            Func<TSecond, TResultSecond> mapSecond)
            =>
            ImplMap(mapFirst, mapSecond);
    }
}
