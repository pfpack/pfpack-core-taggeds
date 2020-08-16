#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TCategory ImplGetOrThrow<TCategory>(
            in Func<Optional<TCategory>> resultFactory,
            in Func<Exception> exceptionFactory)
        {
            _ = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return resultFactory.Invoke().OrThrow(exceptionFactory);
        }
    }
}
