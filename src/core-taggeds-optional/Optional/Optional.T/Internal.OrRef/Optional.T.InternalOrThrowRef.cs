using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ref readonly T InternalOrThrowRef(ref readonly Optional<T> optional)
        =>
        ref InternalOrThrowRef(in optional, InnerCreateExpectedPresentException);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ref readonly T InternalOrThrowRef(ref readonly Optional<T> optional, Func<Exception> exceptionFactory)
    {
        if (optional.hasValue)
        {
            return ref optional.value;
        }

        throw exceptionFactory.Invoke();
    }
}
