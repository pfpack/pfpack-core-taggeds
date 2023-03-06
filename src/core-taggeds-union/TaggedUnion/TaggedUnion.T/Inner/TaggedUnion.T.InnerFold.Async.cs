using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TResult?> InnerFoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync)
    {
        if (tag is Tag.First)
        {
            return mapFirstAsync.Invoke(first)!;
        }

        if (tag is Tag.Second)
        {
            return mapSecondAsync.Invoke(second)!;
        }

        return Task.FromResult<TResult?>(default);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TResult> InnerFoldAsync<TResult>(
        Func<TFirst, Task<TResult>> mapFirstAsync,
        Func<TSecond, Task<TResult>> mapSecondAsync,
        TResult other)
    {
        if (tag is Tag.First)
        {
            return mapFirstAsync.Invoke(first);
        }

        if (tag is Tag.Second)
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
        if (tag is Tag.First)
        {
            return mapFirstAsync.Invoke(first);
        }

        if (tag is Tag.Second)
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
        if (tag is Tag.First)
        {
            return mapFirstAsync.Invoke(first);
        }

        if (tag is Tag.Second)
        {
            return mapSecondAsync.Invoke(second);
        }

        return otherFactoryAsync.Invoke();
    }
}
