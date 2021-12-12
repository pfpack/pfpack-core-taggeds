using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InnerFold<TResult>(
        Func<T, TResult> map,
        Func<TResult> otherFactory)
        =>
        hasValue ? map.Invoke(value) : otherFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TResult> InnerFoldAsync<TResult>(
        Func<T, Task<TResult>> mapAsync,
        Func<Task<TResult>> otherFactoryAsync)
        =>
        hasValue ? mapAsync.Invoke(value) : otherFactoryAsync.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TResult> InnerFoldValueAsync<TResult>(
        Func<T, ValueTask<TResult>> mapAsync,
        Func<ValueTask<TResult>> otherFactoryAsync)
        =>
        hasValue ? mapAsync.Invoke(value) : otherFactoryAsync.Invoke();
}
