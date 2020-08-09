#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TResult Fold<TResult>(
            in Func<TFirst, TResult> mapFirst,
            in Func<TSecond, TResult> mapSecond)
            =>
            ImplFold(mapFirst, mapSecond);

        public Task<TResult> FoldAsync<TResult>(
            in Func<TFirst, Task<TResult>> mapFirstAsync,
            in Func<TSecond, Task<TResult>> mapSecondAsync)
            =>
            ImplFold(mapFirstAsync, mapSecondAsync);

        public ValueTask<TResult> FoldAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> mapFirstAsync,
            in Func<TSecond, ValueTask<TResult>> mapSecondAsync)
            =>
            ImplFold(mapFirstAsync, mapSecondAsync);
    }
}
