using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    private TaggedUnion<TResultFirst, TSecond> InnerMapFirst<TResultFirst>(
        Func<TFirst, TResultFirst> mapFirst)
    {
        if (tag is InternalTag.First)
        {
            return new(mapFirst.Invoke(first));
        }

        if (tag is InternalTag.Second)
        {
            return new(second);
        }

        return default;
    }

    private async Task<TaggedUnion<TResultFirst, TSecond>> InnerMapFirstAsync<TResultFirst>(
        Func<TFirst, Task<TResultFirst>> mapFirstAsync)
    {
        if (tag is InternalTag.First)
        {
            return new(await mapFirstAsync.Invoke(first).ConfigureAwait(false));
        }

        if (tag is InternalTag.Second)
        {
            return new(second);
        }

        return default;
    }

    private async ValueTask<TaggedUnion<TResultFirst, TSecond>> InnerMapFirstValueAsync<TResultFirst>(
        Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync)
    {
        if (tag is InternalTag.First)
        {
            return new(await mapFirstAsync.Invoke(first).ConfigureAwait(false));
        }

        if (tag is InternalTag.Second)
        {
            return new(second);
        }

        return default;
    }
}
