using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<TResult> Map<TResult>(Func<T, TResult> map)
    {
        _ = map ?? throw new ArgumentNullException(nameof(map));

        return InnerFold(MapPresent, static () => default);

        Optional<TResult> MapPresent(T value)
            =>
            new(map.Invoke(value));
    }

    public Task<Optional<TResult>> MapAsync<TResult>(Func<T, Task<TResult>> mapAsync)
    {
        _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

        return InnerFold(MapPresentAsync, static () => Task.FromResult<Optional<TResult>>(default));

        async Task<Optional<TResult>> MapPresentAsync(T value)
            =>
            new(await mapAsync.Invoke(value).ConfigureAwait(false));
    }

    public ValueTask<Optional<TResult>> MapValueAsync<TResult>(Func<T, ValueTask<TResult>> mapAsync)
    {
        _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

        return InnerFold(MapPresentAsync, static () => default);

        async ValueTask<Optional<TResult>> MapPresentAsync(T value)
            =>
            new(await mapAsync.Invoke(value).ConfigureAwait(false));
    }
}
