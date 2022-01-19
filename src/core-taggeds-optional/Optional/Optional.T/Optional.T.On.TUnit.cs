using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the methods
    internal Optional<T> On<TUnit>(
        Func<T, TUnit> onPresent,
        Func<TUnit> onElse)
        =>
        InnerOn(
            onPresent ?? throw new ArgumentNullException(nameof(onPresent)),
            onElse ?? throw new ArgumentNullException(nameof(onElse)));

    internal Task<Optional<T>> OnAsync<TUnit>(
        Func<T, Task<TUnit>> onPresentAsync,
        Func<Task<TUnit>> onElseAsync)
        =>
        InnerOnAsync(
            onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync)),
            onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync)));

    internal ValueTask<Optional<T>> OnValueAsync<TUnit>(
        Func<T, ValueTask<TUnit>> onPresentAsync,
        Func<ValueTask<TUnit>> onElseAsync)
        =>
        InnerOnValueAsync(
            onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync)),
            onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync)));
}
