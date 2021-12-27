using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<TResult?> InnerFoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync)
    {
        if (tag is InternalTag.First)
        {
            return await mapFirstAsync.Invoke(first).ConfigureAwait(false);
        }

        if (tag is InternalTag.Second)
        {
            return await mapSecondAsync.Invoke(second).ConfigureAwait(false);
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TResult> InnerFoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
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

        return Task.FromResult(other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TResult> InnerFoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
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

        return Task.FromResult(otherFactory.Invoke());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TResult> InnerFoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
        Func<Task<TResult>> otherFactoryAsync)
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
