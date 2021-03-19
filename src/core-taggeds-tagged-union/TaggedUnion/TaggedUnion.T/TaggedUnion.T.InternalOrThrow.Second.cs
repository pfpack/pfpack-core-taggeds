#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TSecond InternalSecondOrThrow(Func<Exception> exceptionFactory)
            =>
            tag == Tag.Second
                ? second
                : throw exceptionFactory.Invoke();
    }
}
