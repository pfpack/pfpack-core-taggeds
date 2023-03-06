using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOn<TUnit>(
        Func<TFirst, TUnit> onFirst,
        Func<TSecond, TUnit> onSecond)
    {
        if (tag is Tag.First)
        {
            _ = onFirst.Invoke(first);
        }
        else if (tag is Tag.Second)
        {
            _ = onSecond.Invoke(second);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TaggedUnion<TFirst, TSecond>> InnerOnAsync<TUnit>(
        Func<TFirst, Task<TUnit>> onFirstAsync,
        Func<TSecond, Task<TUnit>> onSecondAsync)
    {
        if (tag is Tag.First)
        {
            _ = await onFirstAsync.Invoke(first).ConfigureAwait(false);
        }
        else if (tag is Tag.Second)
        {
            _ = await onSecondAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<TaggedUnion<TFirst, TSecond>> InnerOnValueAsync<TUnit>(
        Func<TFirst, ValueTask<TUnit>> onFirstAsync,
        Func<TSecond, ValueTask<TUnit>> onSecondAsync)
    {
        if (tag is Tag.First)
        {
            _ = await onFirstAsync.Invoke(first).ConfigureAwait(false);
        }
        else if (tag is Tag.Second)
        {
            _ = await onSecondAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }
}
