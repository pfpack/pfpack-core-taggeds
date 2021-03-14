#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TFirst FirstOrThrow()
            =>
            InternalFirstOrThrow(CreateNotFirstException);

        public TFirst FirstOrThrow(Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));
            
            return InternalFirstOrThrow(exceptionFactory);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TFirst InternalFirstOrThrow(Func<Exception> exceptionFactory)
            =>
            InternalOrThrow(Tag.First, First, exceptionFactory);
    }
}
