#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public T OrThrow() => OrThrow(CreateExpectedPresentException);

        public T OrThrow(in Func<Exception> exceptionFactory)
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            return box ?? throw exceptionFactory.Invoke();
        }
    }
}
