#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TSecond SecondOrThrow()
            =>
            InternalSecondOrThrow(CreateNotSecondException);

        public TSecond SecondOrThrow(Func<Exception> exceptionFactory)
            =>
            InternalSecondOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TSecond InternalSecondOrThrow(Func<Exception> exceptionFactory)
            =>
            InternalOrThrow(Tag.Second, Second, exceptionFactory);
    }
}
