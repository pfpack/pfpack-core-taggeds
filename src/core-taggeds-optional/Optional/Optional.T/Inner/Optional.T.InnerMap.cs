using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<TResult> InnerMap<TResult>(
        Func<T, TResult> map)
        =>
        hasValue
            ? new(map.Invoke(value))
            : default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<TResult>> InnerMapAsync<TResult>(
        Func<T, Task<TResult>> mapAsync)
        =>
        hasValue
            ? new(await mapAsync.Invoke(value).ConfigureAwait(false))
            : default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<TResult>> InnerMapValueAsync<TResult>(
        Func<T, ValueTask<TResult>> mapAsync)
        =>
        hasValue
            ? new(await mapAsync.Invoke(value).ConfigureAwait(false))
            : default;
}
