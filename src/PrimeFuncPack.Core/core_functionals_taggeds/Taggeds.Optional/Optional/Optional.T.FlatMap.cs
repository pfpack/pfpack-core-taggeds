#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> FlatMap<TResult>(Func<T, Optional<TResult>> map)
            =>
            Fold(map, static () => default);

        public Task<Optional<TResult>> FlatMapAsync<TResult>(Func<T, Task<Optional<TResult>>> mapAsync)
            =>
            FoldAsync(mapAsync, static () => Task.FromResult<Optional<TResult>>(default));

        public ValueTask<Optional<TResult>> FlatMapValueAsync<TResult>(Func<T, ValueTask<Optional<TResult>>> mapAsync)
            =>
            FoldValueAsync(mapAsync, static () => default);
    }
}
