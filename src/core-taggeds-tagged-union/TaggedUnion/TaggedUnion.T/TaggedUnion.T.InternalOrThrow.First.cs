#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TFirst InternalFirstOrThrow(Func<Exception> exceptionFactory)
            =>
            tag == Tag.First
                ? first
                : throw exceptionFactory.Invoke();
    }
}
