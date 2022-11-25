using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<T> On(
        Func<T, Unit> onPresent,
        Func<Unit> onElse)
        =>
        InnerOn(
            onPresent ?? throw new ArgumentNullException(nameof(onPresent)),
            onElse ?? throw new ArgumentNullException(nameof(onElse)));

    public Task<Optional<T>> OnAsync(
        Func<T, Task<Unit>> onPresentAsync,
        Func<Task<Unit>> onElseAsync)
        =>
        InnerOnAsync(
            onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync)),
            onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync)));

    public ValueTask<Optional<T>> OnValueAsync(
        Func<T, ValueTask<Unit>> onPresentAsync,
        Func<ValueTask<Unit>> onElseAsync)
        =>
        InnerOnValueAsync(
            onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync)),
            onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync)));
}