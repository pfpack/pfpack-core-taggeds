#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> Map<TResult>(Func<T, TResult> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return ImplFold(MapPresent, () => default);

            Optional<TResult> MapPresent(T value)
                =>
                Optional<TResult>.Present(map.Invoke(value));
        }

        public Task<Optional<TResult>> MapAsync<TResult>(Func<T, Task<TResult>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return ImplFold(MapPresentAsync, () => default(Optional<TResult>));

            async Task<Optional<TResult>> MapPresentAsync(T value)
                =>
                Optional<TResult>.Present(await mapAsync.Invoke(value).ConfigureAwait(false));
        }

        public ValueTask<Optional<TResult>> MapValueAsync<TResult>(Func<T, ValueTask<TResult>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return ImplFold(MapPresentValueAsync, () => default(Optional<TResult>));

            async ValueTask<Optional<TResult>> MapPresentValueAsync(T value)
                =>
                Optional<TResult>.Present(await mapAsync.Invoke(value).ConfigureAwait(false));
        }
    }
}
