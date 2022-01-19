using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnPresent<TUnit>(
        Func<TUnit> handler)
    {
        _ = hasValue ? handler.Invoke() : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnPresentAsync<TUnit>(
        Func<Task<TUnit>> handlerAsync)
    {
        _ = hasValue ? await handlerAsync.Invoke().ConfigureAwait(false) : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnPresentValueAsync<TUnit>(
        Func<ValueTask<TUnit>> handlerAsync)
    {
        _ = hasValue ? await handlerAsync.Invoke().ConfigureAwait(false) : default;

        return this;
    }
}
