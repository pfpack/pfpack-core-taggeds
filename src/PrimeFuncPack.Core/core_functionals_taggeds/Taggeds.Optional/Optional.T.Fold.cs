#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public TResult Fold<TResult>(Func<T, TResult> map, Func<TResult> otherFactory)
            =>
            ImplFold(map, otherFactory);

        public Task<TResult> FoldAsync<TResult>(Func<T, Task<TResult>> mapAsync, Func<Task<TResult>> otherFactoryAsync)
            =>
            ImplFold(mapAsync, otherFactoryAsync);

        public ValueTask<TResult> FoldValueAsync<TResult>(Func<T, ValueTask<TResult>> mapAsync, Func<ValueTask<TResult>> otherFactoryAsync)
            =>
            ImplFold(mapAsync, otherFactoryAsync);
    }
}
