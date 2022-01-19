using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TResult?> InnerFoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync)
    {
        if (tag is InternalTag.First)
        {
            return mapFirstAsync.Invoke(first)!;
        }

        if (tag is InternalTag.Second)
        {
            return mapSecondAsync.Invoke(second)!;
        }

        return ValueTask.FromResult<TResult?>(default);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TResult> InnerFoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync,
        TResult other)
    {
        if (tag is InternalTag.First)
        {
            return mapFirstAsync.Invoke(first);
        }

        if (tag is InternalTag.Second)
        {
            return mapSecondAsync.Invoke(second);
        }

        return ValueTask.FromResult(other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TResult> InnerFoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync,
        Func<TResult> otherFactory)
    {
        if (tag is InternalTag.First)
        {
            return mapFirstAsync.Invoke(first);
        }

        if (tag is InternalTag.Second)
        {
            return mapSecondAsync.Invoke(second);
        }

        return ValueTask.FromResult(otherFactory.Invoke());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TResult> InnerFoldValueAsync<TResult>(
        Func<TFirst, ValueTask<TResult>> mapFirstAsync,
        Func<TSecond, ValueTask<TResult>> mapSecondAsync,
        Func<ValueTask<TResult>> otherFactoryAsync)
    {
        if (tag is InternalTag.First)
        {
            return mapFirstAsync.Invoke(first);
        }

        if (tag is InternalTag.Second)
        {
            return mapSecondAsync.Invoke(second);
        }

        return otherFactoryAsync.Invoke();
    }
}
