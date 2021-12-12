using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOr(
        Func<Optional<T>> otherFactory)
        =>
        hasValue ? this : otherFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<Optional<T>> InnerOrAsync(
        Func<Task<Optional<T>>> otherFactoryAsync)
        =>
        hasValue ? Task.FromResult(this) : otherFactoryAsync.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<Optional<T>> InnerOrValueAsync(
        Func<ValueTask<Optional<T>>> otherFactoryAsync)
        =>
        hasValue ? ValueTask.FromResult(this) : otherFactoryAsync.Invoke();
}
