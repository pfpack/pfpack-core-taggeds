using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnPresent(
        Func<T, Unit> handler)
    {
        _ = hasValue ? handler.Invoke(value) : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnPresentAsync(
        Func<T, Task<Unit>> handlerAsync)
    {
        _ = hasValue ? await handlerAsync.Invoke(value).ConfigureAwait(false) : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnPresentValueAsync(
        Func<T, ValueTask<Unit>> handlerAsync)
    {
        _ = hasValue ? await handlerAsync.Invoke(value).ConfigureAwait(false) : default;

        return this;
    }
}
