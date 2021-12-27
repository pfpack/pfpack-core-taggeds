using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InnerFold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond,
        Func<TResult> otherFactory)
    {
        if (tag is InternalTag.First)
        {
            return mapFirst.Invoke(first);
        }

        if (tag is InternalTag.Second)
        {
            return mapSecond.Invoke(second);
        }

        return otherFactory.Invoke();
    }
}
