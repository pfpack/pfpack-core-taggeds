using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InternalOn<TOnFirstOut, TOnSecondOut, TResult>(
        Func<TFirst, TOnFirstOut> onFirst,
        Func<TSecond, TOnSecondOut> onSecond,
        Func<TResult> resultSupplier)
    {
        if (tag == Tag.First)
        {
            _ = onFirst.Invoke(first);
        }
        else if (tag == Tag.Second)
        {
            _ = onSecond.Invoke(second);
        }

        return resultSupplier.Invoke();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InternalOn<TValue, THandlerOut, TResult>(
        Tag expectedTag,
        Func<TValue> valueSupplier,
        Func<TValue, THandlerOut> handler,
        Func<TResult> resultSupplier)
    {
        if (tag == expectedTag)
        {
            _ = handler.Invoke(valueSupplier.Invoke());
        }

        return resultSupplier.Invoke();
    }
}
