#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        // Map

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

        // Map Async / Task

        public Task<TaggedUnion<TResultFirst, TSecond>> MapFirstAsync<TResultFirst>(
            Func<TFirst, Task<TResultFirst>> mapFirstAsync)
            =>
            ImplMapAsync(mapFirstAsync, Task.FromResult);

        public Task<TaggedUnion<TFirst, TResultSecond>> MapSecondAsync<TResultSecond>(
            Func<TSecond, Task<TResultSecond>> mapSecondAsync)
            =>
            ImplMapAsync(Task.FromResult, mapSecondAsync);

        public Task<TaggedUnion<TResultFirst, TResultSecond>> MapAsync<TResultFirst, TResultSecond>(
            Func<TFirst, Task<TResultFirst>> mapFirstAsync,
            Func<TSecond, Task<TResultSecond>> mapSecondAsync)
            =>
            ImplMapAsync(mapFirstAsync, mapSecondAsync);

        // Map Async / ValueTask

        public ValueTask<TaggedUnion<TResultFirst, TSecond>> MapFirstValueAsync<TResultFirst>(
            Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync)
            =>
            ImplMapValueAsync(mapFirstAsync, ValueTask.FromResult);

        public ValueTask<TaggedUnion<TFirst, TResultSecond>> MapSecondValueAsync<TResultSecond>(
            Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
            =>
            ImplMapValueAsync(ValueTask.FromResult, mapSecondAsync);

        public ValueTask<TaggedUnion<TResultFirst, TResultSecond>> MapValueAsync<TResultFirst, TResultSecond>(
            Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync,
            Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
            =>
            ImplMapValueAsync(mapFirstAsync, mapSecondAsync);
    }
}
