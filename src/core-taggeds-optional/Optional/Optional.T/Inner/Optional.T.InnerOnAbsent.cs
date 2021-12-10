using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnAbsent(
        Action handler)
    {
        if (hasValue is false)
        {
            handler.Invoke();
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnAbsent<TUnit>(
        Func<TUnit> handler)
    {
        if (hasValue is false)
        {
            _ = handler.Invoke();
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnAbsentAsync(
        Func<Task> handlerAsync)
    {
        if (hasValue is false)
        {
            await handlerAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnAbsentAsync<TUnit>(
        Func<Task<TUnit>> handlerAsync)
    {
        if (hasValue is false)
        {
            _ = await handlerAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnAbsentValueAsync(
        Func<ValueTask> handlerAsync)
    {
        if (hasValue is false)
        {
            await handlerAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnAbsentValueAsync<TUnit>(
        Func<ValueTask<TUnit>> handlerAsync)
    {
        if (hasValue is false)
        {
            _ = await handlerAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }
}
