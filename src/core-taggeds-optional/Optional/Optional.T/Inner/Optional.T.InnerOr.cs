using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerOr(
        Func<Optional<T>> otherFactory)
        =>
        hasValue ? this : otherFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InnerOr<TResult>(
        Func<Optional<T>, TResult> map,
        Func<TResult> otherFactory)
        =>
        hasValue ? map.Invoke(this) : otherFactory.Invoke();
}
