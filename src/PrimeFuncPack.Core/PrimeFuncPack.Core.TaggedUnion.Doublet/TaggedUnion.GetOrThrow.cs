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
            ImplOrThrow(First, exceptionFactory);

        public TSecond SecondOrThrow()
            =>
            SecondOrThrow(CreateNotSecondException);

        public TSecond SecondOrThrow(in Func<Exception> exceptionFactory)
            =>
            ImplOrThrow(Second, exceptionFactory);

        private TCategory ImplOrThrow<TCategory>(
            in Func<Optional<TCategory>> instanceFactory,
            in Func<Exception> exceptionFactory)
        {
            _ = instanceFactory ?? throw new ArgumentNullException(nameof(instanceFactory));
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return IsInitialized switch
            {
                true => instanceFactory.Invoke().OrThrow(exceptionFactory),
                _ => throw CreateNotInitializedException()
            };
        }
    }
}
