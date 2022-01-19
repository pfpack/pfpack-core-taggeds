using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> OnFirst(
        Action<TFirst> handler)
        =>
        InnerOnFirst(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<TaggedUnion<TFirst, TSecond>> OnFirstAsync(
        Func<TFirst, Task> handlerAsync)
        =>
        InnerOnFirstAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnFirstValueAsync(
        Func<TFirst, ValueTask> handlerAsync)
        =>
        InnerOnFirstValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
