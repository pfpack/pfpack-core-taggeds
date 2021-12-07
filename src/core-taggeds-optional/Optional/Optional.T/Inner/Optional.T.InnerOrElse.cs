using System.Runtime.CompilerServices;

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
}
