using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    private TaggedUnion<TFirst, TResultSecond> InnerMapSecond<TResultSecond>(
        Func<TSecond, TResultSecond> mapSecond)
    {
        if (tag is InternalTag.First)
        {
            return new(first);
        }

        if (tag is InternalTag.Second)
        {
            return new(mapSecond.Invoke(second));
        }

        return default;
    }

    private async Task<TaggedUnion<TFirst, TResultSecond>> InnerMapSecondAsync<TResultSecond>(
        Func<TSecond, Task<TResultSecond>> mapSecondAsync)
    {
        if (tag is InternalTag.First)
        {
            return new(first);
        }

        if (tag is InternalTag.Second)
        {
            return new(await mapSecondAsync.Invoke(second).ConfigureAwait(false));
        }

        return default;
    }

    private async ValueTask<TaggedUnion<TFirst, TResultSecond>> InnerMapSecondValueAsync<TResultSecond>(
        Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
    {
        if (tag is InternalTag.First)
        {
            return new(first);
        }

        if (tag is InternalTag.Second)
        {
            return new(await mapSecondAsync.Invoke(second).ConfigureAwait(false));
        }

        return default;
    }
}
