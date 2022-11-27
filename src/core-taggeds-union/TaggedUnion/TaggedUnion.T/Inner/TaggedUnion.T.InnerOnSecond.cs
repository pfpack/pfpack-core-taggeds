using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOnSecond(
        Action<TSecond> handler)
    {
        if (tag is Tag.Second)
        {
            handler.Invoke(second);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TaggedUnion<TFirst, TSecond>> InnerOnSecondAsync(
        Func<TSecond, Task> handlerAsync)
    {
        if (tag is Tag.Second)
        {
            await handlerAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<TaggedUnion<TFirst, TSecond>> InnerOnSecondValueAsync(
        Func<TSecond, ValueTask> handlerAsync)
    {
        if (tag is Tag.Second)
        {
            await handlerAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }
}
