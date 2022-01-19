using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the methods
    internal Optional<T> OnPresent(
        Action handler)
        =>
        InnerOnPresent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<Optional<T>> OnPresentAsync(
        Func<Task> handlerAsync)
        =>
        InnerOnPresentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<Optional<T>> OnPresentValueAsync(
        Func<ValueTask> handlerAsync)
        =>
        InnerOnPresentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
