using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public TResult Fold<TResult>(
        Func<T, TResult> map,
        Func<TResult> otherFactory)
        =>
        InnerFold(
            map ?? throw new ArgumentNullException(nameof(map)),
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    public Task<TResult> FoldAsync<TResult>(
        Func<T, Task<TResult>> mapAsync,
        Func<Task<TResult>> otherFactoryAsync)
        =>
        InnerFoldAsync(
            mapAsync ?? throw new ArgumentNullException(nameof(mapAsync)),
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    public ValueTask<TResult> FoldValueAsync<TResult>(
        Func<T, ValueTask<TResult>> mapAsync,
        Func<ValueTask<TResult>> otherFactoryAsync)
        =>
        InnerFoldValueAsync(
            mapAsync ?? throw new ArgumentNullException(nameof(mapAsync)),
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}
