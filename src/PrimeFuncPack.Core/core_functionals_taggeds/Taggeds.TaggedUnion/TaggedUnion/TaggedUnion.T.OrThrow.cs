#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TFirst FirstOrThrow()
            =>
            FirstOrThrow(CreateNotFirstException);

        public TFirst FirstOrThrow(Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return First().OrThrow(exceptionFactory);
        }

        public TSecond SecondOrThrow()
            =>
            SecondOrThrow(CreateNotSecondException);

        public TSecond SecondOrThrow(Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return Second().OrThrow(exceptionFactory);
        }
    }
}
