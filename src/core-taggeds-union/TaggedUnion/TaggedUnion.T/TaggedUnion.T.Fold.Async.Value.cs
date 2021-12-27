using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public ValueTask<TResult> FoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync,
        TResult other)
        =>
        InnerFoldValueAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)),
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)),
            other);

    public ValueTask<TResult> FoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync,
        Func<TResult> otherFactory)
        =>
        InnerFoldValueAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)),
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)),
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    public ValueTask<TResult> FoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync,
        Func<ValueTask<TResult>> otherFactoryAsync)
        =>
        InnerFoldValueAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)),
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)),
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}
