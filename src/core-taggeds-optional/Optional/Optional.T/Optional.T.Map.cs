using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<TResult> Map<TResult>(
        Func<T, TResult> map)
        =>
        InnerMap(
            map ?? throw new ArgumentNullException(nameof(map)));

    public Task<Optional<TResult>> MapAsync<TResult>(
        Func<T, Task<TResult>> mapAsync)
        =>
        InnerMapAsync(
            mapAsync ?? throw new ArgumentNullException(nameof(mapAsync)));

    public ValueTask<Optional<TResult>> MapValueAsync<TResult>(
        Func<T, ValueTask<TResult>> mapAsync)
        =>
        InnerMapValueAsync(
            mapAsync ?? throw new ArgumentNullException(nameof(mapAsync)));
}
