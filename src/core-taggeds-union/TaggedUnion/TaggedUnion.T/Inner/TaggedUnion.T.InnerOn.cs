using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOn(
        Action<TFirst> onFirst,
        Action<TSecond> onSecond)
    {
        if (tag is InternalTag.First)
        {
            onFirst.Invoke(first);
        }
        else if (tag is InternalTag.Second)
        {
            onSecond.Invoke(second);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TaggedUnion<TFirst, TSecond>> InnerOnAsync(
        Func<TFirst, Task> onFirstAsync,
        Func<TSecond, Task> onSecondAsync)
    {
        if (tag is InternalTag.First)
        {
            await onFirstAsync.Invoke(first).ConfigureAwait(false);
        }
        else if (tag is InternalTag.Second)
        {
            await onSecondAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<TaggedUnion<TFirst, TSecond>> InnerOnValueAsync(
        Func<TFirst, ValueTask> onFirstAsync,
        Func<TSecond, ValueTask> onSecondAsync)
    {
        if (tag is InternalTag.First)
        {
            await onFirstAsync.Invoke(first).ConfigureAwait(false);
        }
        else if (tag is InternalTag.Second)
        {
            await onSecondAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }
}
