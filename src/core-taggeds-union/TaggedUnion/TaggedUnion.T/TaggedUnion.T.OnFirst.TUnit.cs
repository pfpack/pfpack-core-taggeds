using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> OnFirst<TUnit>(
        Func<TFirst, TUnit> handler)
        =>
        InnerOnFirst(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<TaggedUnion<TFirst, TSecond>> OnFirstAsync<TUnit>(
        Func<TFirst, Task<TUnit>> handlerAsync)
        =>
        InnerOnFirstAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnFirstValueAsync<TUnit>(
        Func<TFirst, ValueTask<TUnit>> handlerAsync)
        =>
        InnerOnFirstValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
