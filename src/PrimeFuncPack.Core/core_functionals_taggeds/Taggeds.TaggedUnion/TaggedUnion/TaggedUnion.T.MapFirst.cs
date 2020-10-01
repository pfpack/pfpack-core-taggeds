#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TResultFirst, TSecond> MapFirst<TResultFirst>(
            Func<TFirst, TResultFirst> mapFirst)
            =>
            Map(mapFirst, Pipeline.Pipe);

        public Task<TaggedUnion<TResultFirst, TSecond>> MapFirstAsync<TResultFirst>(
            Func<TFirst, Task<TResultFirst>> mapFirstAsync)
            =>
            MapAsync(mapFirstAsync, Task.FromResult);

        public ValueTask<TaggedUnion<TResultFirst, TSecond>> MapFirstValueAsync<TResultFirst>(
            Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync)
            =>
            MapValueAsync(mapFirstAsync, ValueTask.FromResult);
    }
}
