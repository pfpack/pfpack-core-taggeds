using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<T> OnAbsent<TUnit>(
        Func<TUnit> handler)
        =>
        InnerOnAbsent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    public Task<Optional<T>> OnAbsentAsync<TUnit>(
        Func<Task<TUnit>> handlerAsync)
        =>
        InnerOnAbsentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    public ValueTask<Optional<T>> OnAbsentValueAsync<TUnit>(
        Func<ValueTask<TUnit>> handlerAsync)
        =>
        InnerOnAbsentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
