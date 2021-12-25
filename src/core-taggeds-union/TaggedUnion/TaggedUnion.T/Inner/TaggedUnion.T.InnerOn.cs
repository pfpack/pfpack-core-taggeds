using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOn(
        Action<TFirst> onFirst,
        Action<TSecond> onSecond)
    {
        if (tag is InternalTag.First)
        {
            onFirst.Invoke(first);
        }
        else if (tag is InternalTag.Second)
        {
            onSecond.Invoke(second);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOn<TUnit>(
        Func<TFirst, TUnit> onFirst,
        Func<TSecond, TUnit> onSecond)
    {
        if (tag is InternalTag.First)
        {
            _ = onFirst.Invoke(first);
        }
        else if (tag is InternalTag.Second)
        {
            _ = onSecond.Invoke(second);
        }

        return this;
    }
}
