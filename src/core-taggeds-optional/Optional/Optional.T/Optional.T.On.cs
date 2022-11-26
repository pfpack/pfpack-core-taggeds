using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<T> On(
        Action<T> onPresent,
        Action onElse)
        =>
        InnerOn(
            onPresent ?? throw new ArgumentNullException(nameof(onPresent)),
            onElse ?? throw new ArgumentNullException(nameof(onElse)));

    public Task<Optional<T>> OnAsync(
        Func<T, Task> onPresentAsync,
        Func<Task> onElseAsync)
        =>
        InnerOnAsync(
            onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync)),
            onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync)));

    public ValueTask<Optional<T>> OnValueAsync(
        Func<T, ValueTask> onPresentAsync,
        Func<ValueTask> onElseAsync)
        =>
        InnerOnValueAsync(
            onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync)),
            onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync)));
}
