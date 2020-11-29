#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> Map<TResult>(Func<T, TResult> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return Fold(MapPresent, static () => default);

            Optional<TResult> MapPresent(T value)
                =>
                Optional<TResult>.Present(map.Invoke(value));
        }

        public Task<Optional<TResult>> MapAsync<TResult>(Func<T, Task<TResult>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return FoldAsync(MapPresentAsync, () => Task.FromResult<Optional<TResult>>(default));

            async Task<Optional<TResult>> MapPresentAsync(T value)
                =>
                Optional<TResult>.Present(await mapAsync.Invoke(value).ConfigureAwait(false));
        }

        public ValueTask<Optional<TResult>> MapValueAsync<TResult>(Func<T, ValueTask<TResult>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return FoldValueAsync(MapPresentValueAsync, static () => default);

            async ValueTask<Optional<TResult>> MapPresentValueAsync(T value)
                =>
                Optional<TResult>.Present(await mapAsync.Invoke(value).ConfigureAwait(false));
        }
    }
}
