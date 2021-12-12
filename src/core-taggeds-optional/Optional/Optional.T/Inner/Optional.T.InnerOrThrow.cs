using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private T InnerOrThrow(Func<Exception> exceptionFactory)
        =>
        hasValue ? value : throw exceptionFactory.Invoke();
}
