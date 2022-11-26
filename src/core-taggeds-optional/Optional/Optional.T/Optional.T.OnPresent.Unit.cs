using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<T> OnPresent(
        Func<T, Unit> handler)
        =>
        InnerOnPresent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    public Task<Optional<T>> OnPresentAsync(
        Func<T, Task<Unit>> handlerAsync)
        =>
        InnerOnPresentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    public ValueTask<Optional<T>> OnPresentValueAsync(
        Func<T, ValueTask<Unit>> handlerAsync)
        =>
        InnerOnPresentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
