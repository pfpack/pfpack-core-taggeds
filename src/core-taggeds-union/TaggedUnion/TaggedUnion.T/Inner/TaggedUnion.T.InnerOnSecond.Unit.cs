using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOnSecond(
        Func<TSecond, Unit> handler)
    {
        if (tag is Tag.Second)
        {
            _ = handler.Invoke(second);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TaggedUnion<TFirst, TSecond>> InnerOnSecondAsync(
        Func<TSecond, Task<Unit>> handlerAsync)
    {
        if (tag is Tag.Second)
        {
            _ = await handlerAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<TaggedUnion<TFirst, TSecond>> InnerOnSecondValueAsync(
        Func<TSecond, ValueTask<Unit>> handlerAsync)
    {
        if (tag is Tag.Second)
        {
            _ = await handlerAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }
}
