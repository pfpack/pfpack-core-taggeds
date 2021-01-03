#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public T OrThrow()
            =>
            OrThrow(CreateExpectedPresentException);

        public T OrThrow(Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return InternalFold(Pipeline.Pipe, () => throw exceptionFactory.Invoke());
        }
    }
}
