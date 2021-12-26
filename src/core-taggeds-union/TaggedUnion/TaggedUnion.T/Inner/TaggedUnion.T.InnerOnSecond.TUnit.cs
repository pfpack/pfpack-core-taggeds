using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOnSecond<TUnit>(
        Func<TSecond, TUnit> handler)
    {
        if (tag is InternalTag.Second)
        {
            _ = handler.Invoke(second);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TaggedUnion<TFirst, TSecond>> InnerOnSecondAsync<TUnit>(
        Func<TSecond, Task<TUnit>> handlerAsync)
    {
        if (tag is InternalTag.Second)
        {
            _ = await handlerAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<TaggedUnion<TFirst, TSecond>> InnerOnSecondValueAsync<TUnit>(
        Func<TSecond, ValueTask<TUnit>> handlerAsync)
    {
        if (tag is InternalTag.Second)
        {
            _ = await handlerAsync.Invoke(second).ConfigureAwait(false);
        }

        return this;
    }
}
