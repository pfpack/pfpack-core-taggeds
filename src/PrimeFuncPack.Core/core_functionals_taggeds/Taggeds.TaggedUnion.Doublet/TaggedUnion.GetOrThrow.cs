#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TFirst FirstOrThrow()
            =>
            FirstOrThrow(CreateNotTheFirstException);

        public TFirst FirstOrThrow(in Func<Exception> exceptionFactory)
            =>
            First().OrThrow(exceptionFactory);

        public TSecond SecondOrThrow()
            =>
            SecondOrThrow(CreateNotTheSecondException);

        public TSecond SecondOrThrow(in Func<Exception> exceptionFactory)
            =>
            Second().OrThrow(exceptionFactory);
    }
}
