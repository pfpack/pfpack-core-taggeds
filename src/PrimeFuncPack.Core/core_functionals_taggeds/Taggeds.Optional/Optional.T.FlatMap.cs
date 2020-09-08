#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> FlatMap<TResult>(Func<T, Optional<TResult>> map)
            =>
            ImplFold(map, () => default);

        public Task<Optional<TResult>> FlatMapAsync<TResult>(Func<T, Task<Optional<TResult>>> mapAsync)
            =>
            ImplFold(mapAsync, () => default(Optional<TResult>));

        public ValueTask<Optional<TResult>> FlatMapAsync<TResult>(Func<T, ValueTask<Optional<TResult>>> mapAsync)
            =>
            ImplFold(mapAsync, () => default);
    }
}
