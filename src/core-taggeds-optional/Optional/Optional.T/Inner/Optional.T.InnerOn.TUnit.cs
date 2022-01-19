using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOn<TUnit>(
        Func<T, TUnit> onPresent,
        Func<TUnit> onElse)
    {
        _ = hasValue
            ? onPresent.Invoke(value)
            : onElse.Invoke();

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnAsync<TUnit>(
        Func<T, Task<TUnit>> onPresentAsync,
        Func<Task<TUnit>> onElseAsync)
    {
        _ = hasValue
            ? await onPresentAsync.Invoke(value).ConfigureAwait(false)
            : await onElseAsync.Invoke().ConfigureAwait(false);

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnValueAsync<TUnit>(
        Func<T, ValueTask<TUnit>> onPresentAsync,
        Func<ValueTask<TUnit>> onElseAsync)
    {
        _ = hasValue
            ? await onPresentAsync.Invoke(value).ConfigureAwait(false)
            : await onElseAsync.Invoke().ConfigureAwait(false);

        return this;
    }
}
