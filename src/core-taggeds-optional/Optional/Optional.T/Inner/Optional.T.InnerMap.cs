using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    private Optional<TResult> InnerMap<TResult>(
        Func<T, TResult> map)
        =>
        hasValue
            ? new(map.Invoke(value))
            : default;

    private async Task<Optional<TResult>> InnerMapAsync<TResult>(
        Func<T, Task<TResult>> mapAsync)
        =>
        hasValue
            ? new(await mapAsync.Invoke(value).ConfigureAwait(false))
            : default;

    private async ValueTask<Optional<TResult>> InnerMapValueAsync<TResult>(
        Func<T, ValueTask<TResult>> mapAsync)
        =>
        hasValue
            ? new(await mapAsync.Invoke(value).ConfigureAwait(false))
            : default;
}
