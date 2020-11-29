#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TFirst FirstOrThrow()
            =>
            FirstOrThrow(CreateNotFirstException);

        public TFirst FirstOrThrow(Func<Exception> exceptionFactory)
            =>
            first.OrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));

        public TSecond SecondOrThrow()
            =>
            SecondOrThrow(CreateNotSecondException);

        public TSecond SecondOrThrow(Func<Exception> exceptionFactory)
            =>
            second.OrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
    }
}
