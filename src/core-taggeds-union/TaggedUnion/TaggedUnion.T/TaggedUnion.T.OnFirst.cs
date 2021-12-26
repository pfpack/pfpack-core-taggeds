using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> OnFirst(
        Func<TFirst, Unit> handler)
    {
        _ = handler ?? throw new ArgumentNullException(nameof(handler));

        throw new NotImplementedException();
    }

    internal TaggedUnion<TFirst, TSecond> OnFirst(
        Action<TFirst> handler)
    {
        _ = handler ?? throw new ArgumentNullException(nameof(handler));

        throw new NotImplementedException();
    }

    internal Task<TaggedUnion<TFirst, TSecond>> OnFirstAsync(
        Func<TFirst, Task<Unit>> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }

    internal Task<TaggedUnion<TFirst, TSecond>> OnFirstAsync(
        Func<TFirst, Task> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnFirstValueAsync(
        Func<TFirst, ValueTask<Unit>> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnFirstValueAsync(
        Func<TFirst, ValueTask> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }
}
