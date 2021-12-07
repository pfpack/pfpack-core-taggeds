using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<TResult> InnerBindOrFlatMap<TResult>(
        Func<T, Optional<TResult>> map)
        =>
        InnerFold(map, static () => default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<Optional<TResult>> InnerBindOrFlatMapAsync<TResult>(
        Func<T, Task<Optional<TResult>>> mapAsync)
        =>
        InnerFold(mapAsync, static () => Task.FromResult<Optional<TResult>>(default));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<Optional<TResult>> InnerBindOrFlatMapValueAsync<TResult>(
        Func<T, ValueTask<Optional<TResult>>> mapAsync)
        =>
        InnerFold(mapAsync, static () => default);
}
