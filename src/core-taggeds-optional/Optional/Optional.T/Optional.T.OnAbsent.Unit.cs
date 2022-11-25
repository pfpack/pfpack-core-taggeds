using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<T> OnAbsent(
        Func<Unit> handler)
        =>
        InnerOnAbsent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    public Task<Optional<T>> OnAbsentAsync(
        Func<Task<Unit>> handlerAsync)
        =>
        InnerOnAbsentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    public ValueTask<Optional<T>> OnAbsentValueAsync(
        Func<ValueTask<Unit>> handlerAsync)
        =>
        InnerOnAbsentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}