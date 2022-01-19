using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the methods
    internal Optional<T> On(
        Action<T> onPresent,
        Action onElse)
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

    internal ValueTask<Optional<T>> OnValueAsync(
        Func<T, ValueTask> onPresentAsync,
        Func<ValueTask> onElseAsync)
        =>
        InnerOnValueAsync(
            onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync)),
            onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync)));
}
