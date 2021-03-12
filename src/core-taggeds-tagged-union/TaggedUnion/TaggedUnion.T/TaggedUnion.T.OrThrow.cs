#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TFirst FirstOrThrow()
            =>
            first.OrThrow(CreateNotFirstException);

        public TFirst FirstOrThrow(Func<Exception> exceptionFactory)
            =>
            first.OrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));

        public TSecond SecondOrThrow()
            =>
            second.OrThrow(CreateNotSecondException);

        public TSecond SecondOrThrow(Func<Exception> exceptionFactory)
            =>
            second.OrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
    }
}
