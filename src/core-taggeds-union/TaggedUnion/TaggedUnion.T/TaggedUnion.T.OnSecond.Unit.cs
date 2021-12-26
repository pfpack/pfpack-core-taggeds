using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> OnSecond(
        Func<TSecond, Unit> handler)
        =>
        InnerOnSecond(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<TaggedUnion<TFirst, TSecond>> OnSecondAsync(
        Func<TSecond, Task<Unit>> handlerAsync)
        =>
        InnerOnSecondAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnSecondValueAsync(
        Func<TSecond, ValueTask<Unit>> handlerAsync)
        =>
        InnerOnSecondValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
