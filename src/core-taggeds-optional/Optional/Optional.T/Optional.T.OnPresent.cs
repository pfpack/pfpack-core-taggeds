using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<T> OnPresent(
        Action<T> handler)
        =>
        InnerOnPresent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    public Task<Optional<T>> OnPresentAsync(
        Func<T, Task> handlerAsync)
        =>
        InnerOnPresentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    public ValueTask<Optional<T>> OnPresentValueAsync(
        Func<T, ValueTask> handlerAsync)
        =>
        InnerOnPresentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
