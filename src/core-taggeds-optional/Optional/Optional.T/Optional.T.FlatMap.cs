using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<TResult> FlatMap<TResult>(
        Func<T, Optional<TResult>> map)
        =>
        InnerBindOrFlatMap(
            map ?? throw new ArgumentNullException(nameof(map)));

    public Task<Optional<TResult>> FlatMapAsync<TResult>(
        Func<T, Task<Optional<TResult>>> mapAsync)
        =>
        InnerBindOrFlatMapAsync(
            mapAsync ?? throw new ArgumentNullException(nameof(mapAsync)));

    public ValueTask<Optional<TResult>> FlatMapValueAsync<TResult>(
        Func<T, ValueTask<Optional<TResult>>> mapAsync)
        =>
        InnerBindOrFlatMapValueAsync(
            mapAsync ?? throw new ArgumentNullException(nameof(mapAsync)));
}
