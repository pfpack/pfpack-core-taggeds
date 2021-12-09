using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TFirst InternalFirstOrThrow(Func<Exception> exceptionFactory)
        =>
        InternalOrThrow(
            Tag.First, First, exceptionFactory);
}
