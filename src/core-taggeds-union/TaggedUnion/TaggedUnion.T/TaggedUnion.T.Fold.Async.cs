using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the method
    internal Task<TResult?> FoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync)
        =>
        InnerFoldAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)),
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)));

    public Task<TResult> FoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
        TResult other)
        =>
        InnerFoldAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)),
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)),
            other);

    public Task<TResult> FoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
        Func<TResult> otherFactory)
        =>
        InnerFoldAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)),
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)),
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    public Task<TResult> FoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
        Func<Task<TResult>> otherFactoryAsync)
        =>
        InnerFoldAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)),
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)),
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}
