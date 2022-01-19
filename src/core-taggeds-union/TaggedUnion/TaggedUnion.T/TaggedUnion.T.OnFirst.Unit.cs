using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> OnFirst(
        Func<TFirst, Unit> handler)
        =>
        InnerOnFirst(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<TaggedUnion<TFirst, TSecond>> OnFirstAsync(
        Func<TFirst, Task<Unit>> handlerAsync)
        =>
        InnerOnFirstAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnFirstValueAsync(
        Func<TFirst, ValueTask<Unit>> handlerAsync)
        =>
        InnerOnFirstValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
