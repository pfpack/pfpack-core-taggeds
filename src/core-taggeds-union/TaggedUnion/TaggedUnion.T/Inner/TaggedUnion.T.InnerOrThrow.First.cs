using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TFirst InnerFirstOrThrow(Func<Exception> exceptionFactory)
        =>
        tag == Tag.First ? first : throw exceptionFactory.Invoke();
}
