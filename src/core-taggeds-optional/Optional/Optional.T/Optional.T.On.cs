using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    internal Optional<T> On(
        Action<T> onPresent,
        Action onElse)
        =>
        InnerOn(
            onPresent ?? throw new ArgumentNullException(nameof(onPresent)),
            onElse ?? throw new ArgumentNullException(nameof(onElse)));

    internal Optional<T> On<TUnit>(
        Func<T, TUnit> onPresent,
        Func<TUnit> onElse)
        =>
        InnerOn(
            onPresent ?? throw new ArgumentNullException(nameof(onPresent)),
            onElse ?? throw new ArgumentNullException(nameof(onElse)));

    internal Task<Optional<T>> OnAsync(
        Func<T, Task> onPresentAsync,
        Func<Task> onElseAsync)
        =>
        InnerOnAsync(
            onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync)),
            onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync)));

    internal Task<Optional<T>> OnAsync<TUnit>(
        Func<T, Task<TUnit>> onPresentAsync,
        Func<Task<TUnit>> onElseAsync)
        =>
        InnerOnAsync(
            onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync)),
            onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync)));

    internal ValueTask<Optional<T>> OnValueAsync(
        Func<T, ValueTask> onPresentAsync,
        Func<ValueTask> onElseAsync)
        =>
        InnerOnValueAsync(
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
