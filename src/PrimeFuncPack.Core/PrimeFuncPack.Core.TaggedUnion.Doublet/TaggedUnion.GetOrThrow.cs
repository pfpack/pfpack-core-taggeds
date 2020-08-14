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

        private TCategory ImplGetOrThrow<TCategory>(
            in Func<Optional<TCategory>> resultFactory,
            in Func<Exception> exceptionFactory)
        {
            _ = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return IsInitialized switch
            {
                true => resultFactory.Invoke().OrThrow(exceptionFactory),
                _ => throw CreateNotInitializedException()
            };
        }
    }
}
