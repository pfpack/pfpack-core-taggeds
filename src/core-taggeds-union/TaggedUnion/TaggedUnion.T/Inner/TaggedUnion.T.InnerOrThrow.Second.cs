using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TSecond InnerSecondOrThrow(Func<Exception> exceptionFactory)
        =>
        tag is InternalTag.Second ? second : throw exceptionFactory.Invoke();
}
