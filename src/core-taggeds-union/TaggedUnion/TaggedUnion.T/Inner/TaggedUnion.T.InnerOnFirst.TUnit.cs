using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOnFirst<TUnit>(
        Func<TFirst, TUnit> handler)
    {
        if (tag is Tag.First)
        {
            _ = handler.Invoke(first);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TaggedUnion<TFirst, TSecond>> InnerOnFirstAsync<TUnit>(
        Func<TFirst, Task<TUnit>> handlerAsync)
    {
        if (tag is Tag.First)
        {
            _ = await handlerAsync.Invoke(first).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<TaggedUnion<TFirst, TSecond>> InnerOnFirstValueAsync<TUnit>(
        Func<TFirst, ValueTask<TUnit>> handlerAsync)
    {
        if (tag is Tag.First)
        {
            _ = await handlerAsync.Invoke(first).ConfigureAwait(false);
        }

        return this;
    }
}
