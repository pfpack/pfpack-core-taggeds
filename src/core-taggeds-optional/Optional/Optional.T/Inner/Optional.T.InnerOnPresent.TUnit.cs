using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnPresent<TUnit>(
        Func<T, TUnit> handler)
    {
        _ = hasValue ? handler.Invoke(value) : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnPresentAsync<TUnit>(
        Func<T, Task<TUnit>> handlerAsync)
    {
        _ = hasValue ? await handlerAsync.Invoke(value).ConfigureAwait(false) : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnPresentValueAsync<TUnit>(
        Func<T, ValueTask<TUnit>> handlerAsync)
    {
        _ = hasValue ? await handlerAsync.Invoke(value).ConfigureAwait(false) : default;

        return this;
    }
}
