using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOn(
        Func<T, Unit> onPresent,
        Func<Unit> onElse)
    {
        _ = hasValue
            ? onPresent.Invoke(value)
            : onElse.Invoke();

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnAsync(
        Func<T, Task<Unit>> onPresentAsync,
        Func<Task<Unit>> onElseAsync)
    {
        _ = hasValue
            ? await onPresentAsync.Invoke(value).ConfigureAwait(false)
            : await onElseAsync.Invoke().ConfigureAwait(false);

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnValueAsync(
        Func<T, ValueTask<Unit>> onPresentAsync,
        Func<ValueTask<Unit>> onElseAsync)
    {
        _ = hasValue
            ? await onPresentAsync.Invoke(value).ConfigureAwait(false)
            : await onElseAsync.Invoke().ConfigureAwait(false);

        return this;
    }
}
