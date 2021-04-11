#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TSecond InternalSecondOrThrow(Func<Exception> exceptionFactory)
            =>
            InternalOrThrow(
                Tag.Second, Second, exceptionFactory);
    }
}
