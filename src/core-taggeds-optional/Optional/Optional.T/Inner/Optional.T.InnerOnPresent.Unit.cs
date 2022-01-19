using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnPresent(
        Func<Unit> handler)
    {
        _ = hasValue ? handler.Invoke() : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnPresentAsync(
        Func<Task<Unit>> handlerAsync)
    {
        _ = hasValue ? await handlerAsync.Invoke().ConfigureAwait(false) : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnPresentValueAsync(
        Func<ValueTask<Unit>> handlerAsync)
    {
        _ = hasValue ? await handlerAsync.Invoke().ConfigureAwait(false) : default;

        return this;
    }
}
