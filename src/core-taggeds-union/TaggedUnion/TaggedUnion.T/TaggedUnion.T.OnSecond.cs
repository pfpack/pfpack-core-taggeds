using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> OnSecond(
        Action<TSecond> handler)
        =>
        InnerOnSecond(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<TaggedUnion<TFirst, TSecond>> OnSecondAsync(
        Func<TSecond, Task> handlerAsync)
        =>
        InnerOnSecondAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnSecondValueAsync(
        Func<TSecond, ValueTask> handlerAsync)
        =>
        InnerOnSecondValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
