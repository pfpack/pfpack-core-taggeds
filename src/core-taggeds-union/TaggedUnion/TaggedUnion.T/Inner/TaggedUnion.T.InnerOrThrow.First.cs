using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TFirst InnerFirstOrThrow(Func<Exception> exceptionFactory)
        =>
        tag is Tag.First ? first : throw exceptionFactory.Invoke();
}
