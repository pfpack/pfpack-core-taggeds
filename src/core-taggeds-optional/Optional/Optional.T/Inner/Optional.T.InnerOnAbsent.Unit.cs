using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOnAbsent(
        Func<Unit> handler)
    {
        _ = hasValue is false ? handler.Invoke() : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerOnAbsentAsync(
        Func<Task<Unit>> handlerAsync)
    {
        _ = hasValue is false ? await handlerAsync.Invoke().ConfigureAwait(false) : default;

        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerOnAbsentValueAsync(
        Func<ValueTask<Unit>> handlerAsync)
    {
        _ = hasValue is false ? await handlerAsync.Invoke().ConfigureAwait(false) : default;

        return this;
    }
}
