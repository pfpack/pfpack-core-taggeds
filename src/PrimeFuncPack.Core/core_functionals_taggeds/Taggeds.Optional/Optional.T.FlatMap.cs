#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> FlatMap<TResult>(in Func<T, Optional<TResult>> map)
            =>
            ImplFold(map, () => default);

        public Task<Optional<TResult>> FlatMapAsync<TResult>(in Func<T, Task<Optional<TResult>>> mapAsync)
            =>
            ImplFold(mapAsync, () => Task.FromResult<Optional<TResult>>(default));

        public ValueTask<Optional<TResult>> FlatMapAsync<TResult>(in Func<T, ValueTask<Optional<TResult>>> mapAsync)
            =>
            ImplFold(mapAsync, () => default);
    }
}
