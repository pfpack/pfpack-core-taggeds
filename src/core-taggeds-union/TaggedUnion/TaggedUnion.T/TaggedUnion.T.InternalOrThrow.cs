#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TValue InternalOrThrow<TValue>(
            Tag expectedTag,
            Func<TValue> valueSupplier,
            Func<Exception> exceptionFactory)
            =>
            tag == expectedTag
                ? valueSupplier.Invoke()
                : throw exceptionFactory.Invoke();
    }
}
