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
    private async ValueTask<Optional<T>> InnerOnPresentValueAsync(
        Func<ValueTask> handlerAsync)
    {
        if (hasValue)
        {
            await handlerAsync.Invoke().ConfigureAwait(false);
        }

        return this;
    }
}
