using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOn(
        Func<TFirst, Unit> onFirst,
        Func<TSecond, Unit> onSecond)
    {
        if (tag is InternalTag.First)
        {
            _ = onFirst.Invoke(first);
        }
        else if (tag is InternalTag.Second)
        {
            _ = onSecond.Invoke(second);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TaggedUnion<TFirst, TSecond>> InnerOnAsync(
        Func<TFirst, Task<Unit>> onFirstAsync,
        Func<TSecond, Task<Unit>> onSecondAsync)
    {
        if (tag is InternalTag.First)
        {
            _ = await onFirstAsync.Invoke(first).ConfigureAwait(false);
        }
        else if (tag is InternalTag.Second)
        {
            _ = await onSecondAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<TaggedUnion<TFirst, TSecond>> InnerOnValueAsync(
        Func<TFirst, ValueTask<Unit>> onFirstAsync,
        Func<TSecond, ValueTask<Unit>> onSecondAsync)
    {
        if (tag is InternalTag.First)
        {
            _ = await onFirstAsync.Invoke(first).ConfigureAwait(false);
        }
        else if (tag is InternalTag.Second)
        {
            _ = await onSecondAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }
}
