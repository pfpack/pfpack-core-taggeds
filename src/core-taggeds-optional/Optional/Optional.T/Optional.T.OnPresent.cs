using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    internal Optional<T> OnPresent(
        Action handler)
        =>
        InnerOnPresent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Optional<T> OnPresent<TUnit>(
        Func<TUnit> handler)
        =>
        InnerOnPresent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<Optional<T>> OnPresentAsync(
        Func<Task> handlerAsync)
        =>
        InnerOnPresentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal Task<Optional<T>> OnPresentAsync<TUnit>(
        Func<Task<TUnit>> handlerAsync)
        =>
        InnerOnPresentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<Optional<T>> OnPresentValueAsync(
        Func<ValueTask> handlerAsync)
        =>
        InnerOnPresentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<Optional<T>> OnPresentValueAsync<TUnit>(
        Func<ValueTask<TUnit>> handlerAsync)
        =>
        InnerOnPresentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
