using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TaggedUnion<TFirst, TSecond> OnSecond(
        Func<TSecond, Unit> handler)
    {
        _ = handler ?? throw new ArgumentNullException(nameof(handler));

        throw new NotImplementedException();
    }

    public TaggedUnion<TFirst, TSecond> OnSecond(
        Action<TSecond> handler)
    {
        _ = handler ?? throw new ArgumentNullException(nameof(handler));

        throw new NotImplementedException();
    }

    public Task<TaggedUnion<TFirst, TSecond>> OnSecondAsync(
        Func<TSecond, Task<Unit>> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }

    public Task<TaggedUnion<TFirst, TSecond>> OnSecondAsync(
        Func<TSecond, Task> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }

    public ValueTask<TaggedUnion<TFirst, TSecond>> OnSecondValueAsync(
        Func<TSecond, ValueTask<Unit>> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }

    public ValueTask<TaggedUnion<TFirst, TSecond>> OnSecondValueAsync(
        Func<TSecond, ValueTask> handlerAsync)
    {
        _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

        throw new NotImplementedException();
    }
}
