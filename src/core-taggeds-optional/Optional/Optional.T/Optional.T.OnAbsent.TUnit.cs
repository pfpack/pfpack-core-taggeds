using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the methods
    internal Optional<T> OnAbsent<TUnit>(
        Func<TUnit> handler)
        =>
        InnerOnAbsent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<Optional<T>> OnAbsentAsync<TUnit>(
        Func<Task<TUnit>> handlerAsync)
        =>
        InnerOnAbsentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<Optional<T>> OnAbsentValueAsync<TUnit>(
        Func<ValueTask<TUnit>> handlerAsync)
        =>
        InnerOnAbsentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
