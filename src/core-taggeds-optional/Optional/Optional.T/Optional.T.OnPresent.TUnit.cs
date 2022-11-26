using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<T> OnPresent<TUnit>(
        Func<T, TUnit> handler)
        =>
        InnerOnPresent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    public Task<Optional<T>> OnPresentAsync<TUnit>(
        Func<T, Task<TUnit>> handlerAsync)
        =>
        InnerOnPresentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    public ValueTask<Optional<T>> OnPresentValueAsync<TUnit>(
        Func<T, ValueTask<TUnit>> handlerAsync)
        =>
        InnerOnPresentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}