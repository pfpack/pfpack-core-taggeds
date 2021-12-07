using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private T InnerOrElse(T other)
        =>
        hasValue ? value : other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private T InnerOrElse(Func<T> otherFactory)
        =>
        hasValue ? value : otherFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<T> InnerOrElseAsync(
        Func<Task<T>> otherFactoryAsync)
        =>
        hasValue ? Task.FromResult(value) : otherFactoryAsync.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<T> InnerOrElseValueAsync(
        Func<ValueTask<T>> otherFactoryAsync)
        =>
        hasValue ? ValueTask.FromResult(value) : otherFactoryAsync.Invoke();
}
