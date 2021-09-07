#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> Map<TResult>(Func<T, TResult> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return InnerFold(MapPresent, static () => default);

            Optional<TResult> MapPresent(T value)
                =>
                Pipeline
                .Pipe(map.Invoke(value))
                .Pipe(Optional<TResult>.Present);
        }

        public Task<Optional<TResult>> MapAsync<TResult>(Func<T, Task<TResult>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return InnerFold(MapPresentAsync, static () => default(Optional<TResult>).Pipe(Task.FromResult));

            async Task<Optional<TResult>> MapPresentAsync(T value)
                =>
                Pipeline
                .Pipe(await mapAsync.Invoke(value).ConfigureAwait(false))
                .Pipe(Optional<TResult>.Present);
        }

        public ValueTask<Optional<TResult>> MapValueAsync<TResult>(Func<T, ValueTask<TResult>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return InnerFold(MapPresentAsync, static () => default);

            async ValueTask<Optional<TResult>> MapPresentAsync(T value)
                =>
                Pipeline
                .Pipe(await mapAsync.Invoke(value).ConfigureAwait(false))
                .Pipe(Optional<TResult>.Present);
        }
    }
}
