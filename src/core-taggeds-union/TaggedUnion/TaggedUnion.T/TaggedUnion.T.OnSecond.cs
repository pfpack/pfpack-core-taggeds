using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> OnSecond(
        Func<TSecond, Unit> handler)
    {
        _ = handler ?? throw new ArgumentNullException(nameof(handler));

        throw new NotImplementedException();
    }

    internal TaggedUnion<TFirst, TSecond> OnSecond(
        Action<TSecond> handler)
    {
        _ = handler ?? throw new ArgumentNullException(nameof(handler));

        throw new NotImplementedException();
    }

    internal Task<TaggedUnion<TFirst, TSecond>> OnSecondAsync(
        Func<TSecond, Task<Unit>> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }

    internal Task<TaggedUnion<TFirst, TSecond>> OnSecondAsync(
        Func<TSecond, Task> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnSecondValueAsync(
        Func<TSecond, ValueTask<Unit>> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnSecondValueAsync(
        Func<TSecond, ValueTask> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }
}
