#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TFirst FirstOrThrow()
            =>
            FirstOrThrow(CreateNotFirstException);

        public TFirst FirstOrThrow(in Func<Exception> exceptionFactory)
            =>
            ImplGetOrThrow(WrapFirst, exceptionFactory);

        public TSecond SecondOrThrow()
            =>
            SecondOrThrow(CreateNotSecondException);

        public TSecond SecondOrThrow(in Func<Exception> exceptionFactory)
            =>
            ImplGetOrThrow(WrapSecond, exceptionFactory);
    }
}
