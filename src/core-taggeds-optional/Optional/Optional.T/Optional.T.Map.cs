#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> Map<TResult>(Func<T, TResult> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return InternalHandleFold(Map, static () => default);

            Optional<TResult> Map(T value)
                =>
                Optional<TResult>.Present(map.Invoke(value));
        }

        public Task<Optional<TResult>> MapAsync<TResult>(Func<T, Task<TResult>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return InternalHandleFold(MapAsync, static () => Task.FromResult<Optional<TResult>>(default));

            async Task<Optional<TResult>> MapAsync(T value)
                =>
                Optional<TResult>.Present(await mapAsync.Invoke(value).ConfigureAwait(false));
        }

        public ValueTask<Optional<TResult>> MapValueAsync<TResult>(Func<T, ValueTask<TResult>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return InternalHandleFold(MapValueAsync, static () => default);

            async ValueTask<Optional<TResult>> MapValueAsync(T value)
                =>
                Optional<TResult>.Present(await mapAsync.Invoke(value).ConfigureAwait(false));
        }
    }
}
