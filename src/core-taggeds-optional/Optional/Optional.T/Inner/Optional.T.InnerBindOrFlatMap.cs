using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<TResult> InnerBindOrFlatMap<TResult>(
        Func<T, Optional<TResult>> binderOrMap)
        =>
        hasValue ? binderOrMap.Invoke(value) : default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<Optional<TResult>> InnerBindOrFlatMapAsync<TResult>(
        Func<T, Task<Optional<TResult>>> binderOrMapAsync)
        =>
        hasValue ? binderOrMapAsync.Invoke(value) : Task.FromResult(default(Optional<TResult>));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<Optional<TResult>> InnerBindOrFlatMapValueAsync<TResult>(
        Func<T, ValueTask<Optional<TResult>>> binderOrMapAsync)
        =>
        hasValue ? binderOrMapAsync.Invoke(value) : default;
}
