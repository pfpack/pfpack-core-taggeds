#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TFirst, TResultSecond> MapSecond<TResultSecond>(
            Func<TSecond, TResultSecond> mapSecond)
            =>
            Map(Pipeline.Pipe, mapSecond);

        public Task<TaggedUnion<TFirst, TResultSecond>> MapSecondAsync<TResultSecond>(
            Func<TSecond, Task<TResultSecond>> mapSecondAsync)
            =>
            MapAsync(Task.FromResult, mapSecondAsync);

        public ValueTask<TaggedUnion<TFirst, TResultSecond>> MapSecondValueAsync<TResultSecond>(
            Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
            =>
            MapValueAsync(ValueTask.FromResult, mapSecondAsync);
    }
}
