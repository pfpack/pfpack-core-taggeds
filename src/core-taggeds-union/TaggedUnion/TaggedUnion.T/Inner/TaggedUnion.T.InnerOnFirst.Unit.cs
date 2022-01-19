using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOnFirst(
        Func<TFirst, Unit> handler)
    {
        if (tag is InternalTag.First)
        {
            _ = handler.Invoke(first);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TaggedUnion<TFirst, TSecond>> InnerOnFirstAsync(
        Func<TFirst, Task<Unit>> handlerAsync)
    {
        if (tag is InternalTag.First)
        {
            _ = await handlerAsync.Invoke(first).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<TaggedUnion<TFirst, TSecond>> InnerOnFirstValueAsync(
        Func<TFirst, ValueTask<Unit>> handlerAsync)
    {
        if (tag is InternalTag.First)
        {
            _ = await handlerAsync.Invoke(first).ConfigureAwait(false);
        }

        return this;
    }
}
