#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public T OrElseThrow()
            =>
            box ?? throw new InvalidOperationException("The optional does not have a value.");

        public T OrElseThrow(in Func<Exception> exceptionFactory)
            =>
            box ?? throw exceptionFactory.Invoke();
    }
}
