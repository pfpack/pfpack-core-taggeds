using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // Fold

    public TResult? Fold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond)
    {
        _ = mapFirst ?? throw new ArgumentNullException(nameof(mapFirst));
        _ = mapSecond ?? throw new ArgumentNullException(nameof(mapSecond));

        return InnerFold(mapFirst, mapSecond, static () => default!);
    }

    public TResult Fold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond,
        TResult other)
    {
        _ = mapFirst ?? throw new ArgumentNullException(nameof(mapFirst));
        _ = mapSecond ?? throw new ArgumentNullException(nameof(mapSecond));

        return InnerFold(mapFirst, mapSecond, () => other);
    }

    public TResult Fold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond,
        Func<TResult> otherFactory)
    {
        _ = mapFirst ?? throw new ArgumentNullException(nameof(mapFirst));
        _ = mapSecond ?? throw new ArgumentNullException(nameof(mapSecond));
        _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

        return InnerFold(mapFirst, mapSecond, otherFactory);
    }

    // Fold Async / Task

    public Task<TResult> FoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
        TResult other)
    {
        _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
        _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));

        return InnerFold(mapFirstAsync, mapSecondAsync, () => Task.FromResult(other));
    }

    public Task<TResult> FoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
        Func<TResult> otherFactory)
    {
        _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
        _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));
        _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

        return InnerFold(mapFirstAsync, mapSecondAsync, () => Task.FromResult(otherFactory.Invoke()));
    }

    public Task<TResult> FoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
        Func<Task<TResult>> otherFactoryAsync)
    {
        _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
        _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));
        _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

        return InnerFold(mapFirstAsync, mapSecondAsync, otherFactoryAsync);
    }

    // Fold Async / ValueTask

    public ValueTask<TResult> FoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync,
        TResult other)
    {
        _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
        _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));

        return InnerFold(mapFirstAsync, mapSecondAsync, () => ValueTask.FromResult(other));
    }

    public ValueTask<TResult> FoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync,
        Func<TResult> otherFactory)
    {
        _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
        _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));
        _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

        return InnerFold(mapFirstAsync, mapSecondAsync, () => ValueTask.FromResult(otherFactory.Invoke()));
    }

    public ValueTask<TResult> FoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync,
        Func<ValueTask<TResult>> otherFactoryAsync)
    {
        _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
        _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));
        _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

        return InnerFold(mapFirstAsync, mapSecondAsync, otherFactoryAsync);
    }
}
