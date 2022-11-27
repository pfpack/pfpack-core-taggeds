using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult? InnerFold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond)
    {
        if (tag is Tag.First)
        {
            return mapFirst.Invoke(first);
        }

        if (tag is Tag.Second)
        {
            return mapSecond.Invoke(second);
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InnerFold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond,
        TResult other)
    {
        if (tag is Tag.First)
        {
            return mapFirst.Invoke(first);
        }

        if (tag is Tag.Second)
        {
            return mapSecond.Invoke(second);
        }

        return other;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InnerFold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond,
        Func<TResult> otherFactory)
    {
        if (tag is Tag.First)
        {
            return mapFirst.Invoke(first);
        }

        if (tag is Tag.Second)
        {
            return mapSecond.Invoke(second);
        }

        return otherFactory.Invoke();
    }
}
