using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    private TaggedUnion<TResultFirst, TResultSecond> InnerMap<TResultFirst, TResultSecond>(
        Func<TFirst, TResultFirst> mapFirst,
        Func<TSecond, TResultSecond> mapSecond)
    {
        if (tag is Tag.First)
        {
            return new(mapFirst.Invoke(first));
        }

        if (tag is Tag.Second)
        {
            return new(mapSecond.Invoke(second));
        }

        return default;
    }

    private async Task<TaggedUnion<TResultFirst, TResultSecond>> InnerMapAsync<TResultFirst, TResultSecond>(
        Func<TFirst, Task<TResultFirst>> mapFirstAsync,
        Func<TSecond, Task<TResultSecond>> mapSecondAsync)
    {
        if (tag is Tag.First)
        {
            return new(await mapFirstAsync.Invoke(first).ConfigureAwait(false));
        }

        if (tag is Tag.Second)
        {
            return new(await mapSecondAsync.Invoke(second).ConfigureAwait(false));
        }

        return default;
    }

    private async ValueTask<TaggedUnion<TResultFirst, TResultSecond>> InnerMapValueAsync<TResultFirst, TResultSecond>(
        Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync,
        Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
    {
        if (tag is Tag.First)
        {
            return new(await mapFirstAsync.Invoke(first).ConfigureAwait(false));
        }

        if (tag is Tag.Second)
        {
            return new(await mapSecondAsync.Invoke(second).ConfigureAwait(false));
        }

        return default;
    }
}
