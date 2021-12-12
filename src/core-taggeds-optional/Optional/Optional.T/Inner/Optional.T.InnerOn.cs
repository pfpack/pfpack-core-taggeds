using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOn(
        Action<T> onPresent,
        Action onElse)
    {
        if (hasValue)
        {
            onPresent.Invoke(value);
        }
        else
        {
            onElse.Invoke();
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOn<TUnit>(
        Func<T, TUnit> onPresent,
        Func<TUnit> onElse)
    {
        if (hasValue)
        {
            _ = onPresent.Invoke(value);
        }
        else
        {
            _ = onElse.Invoke();
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnAsync(
        Func<T, Task> onPresentAsync,
        Func<Task> onElseAsync)
    {
        if (hasValue)
        {
            await onPresentAsync.Invoke(value).ConfigureAwait(false);
        }
        else
        {
            await onElseAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnAsync<TUnit>(
        Func<T, Task<TUnit>> onPresentAsync,
        Func<Task<TUnit>> onElseAsync)
    {
        if (hasValue)
        {
            _ = await onPresentAsync.Invoke(value).ConfigureAwait(false);
        }
        else
        {
            _ = await onElseAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnValueAsync(
        Func<T, ValueTask> onPresentAsync,
        Func<ValueTask> onElseAsync)
    {
        if (hasValue)
        {
            await onPresentAsync.Invoke(value).ConfigureAwait(false);
        }
        else
        {
            await onElseAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnValueAsync<TUnit>(
        Func<T, ValueTask<TUnit>> onPresentAsync,
        Func<ValueTask<TUnit>> onElseAsync)
    {
        if (hasValue)
        {
            _ = await onPresentAsync.Invoke(value).ConfigureAwait(false);
        }
        else
        {
            _ = await onElseAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }
}
