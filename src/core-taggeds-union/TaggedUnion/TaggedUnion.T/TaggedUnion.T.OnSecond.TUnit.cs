using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> OnSecond<TUnit>(
        Func<TSecond, TUnit> handler)
        =>
        InnerOnSecond(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<TaggedUnion<TFirst, TSecond>> OnSecondAsync<TUnit>(
        Func<TSecond, Task<TUnit>> handlerAsync)
        =>
        InnerOnSecondAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnSecondValueAsync<TUnit>(
        Func<TSecond, ValueTask<TUnit>> handlerAsync)
        =>
        InnerOnSecondValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
