using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InnerFold<TResult>(
        Func<T, TResult> map,
        Func<TResult> otherFactory)
        =>
        hasValue
            ? map.Invoke(value)
            : otherFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TResult InnerFold<TResult>(
        Func<T, TResult> map,
        TResult other)
        =>
        hasValue
            ? map.Invoke(value)
            : other;
}
