#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TValue InternalOrThrow<TValue>(
            Tag expectedTag,
            Func<TValue> supplier,
            Func<Exception> exceptionFactory)
            =>
            tag == expectedTag
                ? supplier.Invoke()
                : throw exceptionFactory.Invoke();
    }
}
