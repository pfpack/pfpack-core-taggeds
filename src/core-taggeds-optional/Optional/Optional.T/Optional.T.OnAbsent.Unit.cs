using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the methods
    internal Optional<T> OnAbsent(
        Func<Unit> handler)
        =>
        InnerOnAbsent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<Optional<T>> OnAbsentAsync(
        Func<Task<Unit>> handlerAsync)
        =>
        InnerOnAbsentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<Optional<T>> OnAbsentValueAsync(
        Func<ValueTask<Unit>> handlerAsync)
        =>
        InnerOnAbsentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
