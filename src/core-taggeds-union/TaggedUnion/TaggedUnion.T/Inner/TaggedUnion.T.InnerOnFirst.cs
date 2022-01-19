using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOnFirst(
        Action<TFirst> handler)
    {
        if (tag is InternalTag.First)
        {
            handler.Invoke(first);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TaggedUnion<TFirst, TSecond>> InnerOnFirstAsync(
        Func<TFirst, Task> handlerAsync)
    {
        if (tag is InternalTag.First)
        {
            await handlerAsync.Invoke(first).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<TaggedUnion<TFirst, TSecond>> InnerOnFirstValueAsync(
        Func<TFirst, ValueTask> handlerAsync)
    {
        if (tag is InternalTag.First)
        {
            await handlerAsync.Invoke(first).ConfigureAwait(false);
        }

        return this;
    }
}
