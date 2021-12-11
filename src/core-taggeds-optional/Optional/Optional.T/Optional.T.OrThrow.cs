namespace System;

partial struct Optional<T>
{
    public T OrThrow()
        =>
        InnerOrThrow(InnerCreateExpectedPresentException);

    public T OrThrow(Func<Exception> exceptionFactory)
        =>
        InnerOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
}
