using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnPresent(
        Action<T> handler)
    {
        if (hasValue)
        {
            handler.Invoke(value);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnPresentAsync(
        Func<T, Task> handlerAsync)
    {
        if (hasValue)
        {
            await handlerAsync.Invoke(value).ConfigureAwait(false);
        }

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnPresentValueAsync(
        Func<T, ValueTask> handlerAsync)
    {
        if (hasValue)
        {
            await handlerAsync.Invoke(value).ConfigureAwait(false);
        }

        return this;
    }
}
