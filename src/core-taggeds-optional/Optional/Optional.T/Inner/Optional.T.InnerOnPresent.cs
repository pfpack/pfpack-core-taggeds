using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnPresent(
        Action handler)
    {
        if (hasValue)
        {
            handler.Invoke();
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnPresent<TUnit>(
        Func<TUnit> handler)
    {
        if (hasValue)
        {
            _ = handler.Invoke();
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnPresentAsync(
        Func<Task> handlerAsync)
    {
        if (hasValue)
        {
            await handlerAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnPresentAsync<TUnit>(
        Func<Task<TUnit>> handlerAsync)
    {
        if (hasValue)
        {
            _ = await handlerAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnPresentValueAsync(
        Func<ValueTask> handlerAsync)
    {
        if (hasValue)
        {
            await handlerAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnPresentValueAsync<TUnit>(
        Func<ValueTask<TUnit>> handlerAsync)
    {
        if (hasValue)
        {
            _ = await handlerAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }
}
