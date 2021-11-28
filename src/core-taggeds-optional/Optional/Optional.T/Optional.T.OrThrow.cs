namespace System;

partial struct Optional<T>
{
    public T OrThrow()
        =>
        InnerOrThrow(InnerCreateExpectedPresentException);

    public T OrThrow(Func<Exception> exceptionFactory)
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return InnerOrThrow(exceptionFactory);
    }
}
